{-# LANGUAGE LambdaCase, FlexibleContexts #-}
module Gy09 where

import Control.Monad.State
import Control.Monad.Except
import Data.List
import Data.Bifunctor
import Control.Monad
import Data.Functor
import Data.Char
import Data.Foldable
import CoreSyn (Expr(Type))

-- Parser

type Parser a = StateT String (Except String) a

runParser :: Parser a -> String -> Either String (a, String)
runParser p s = runExcept (runStateT p s)

(<|>) :: MonadError e m => m a -> m a -> m a
f <|> g = catchError f (const g)
infixl 3 <|>

optional :: MonadError e m => m a -> m (Maybe a)
optional f = Just <$> f <|> pure Nothing

many :: MonadError e m => m a -> m [a]
many p = some p <|> pure []

some :: MonadError e m => m a -> m [a]
some p = (:) <$> p <*> many p

-- Primitívek

satisfy :: (Char -> Bool) -> Parser Char
satisfy p = get >>= \case
  (c:cs) | p c -> c <$ put cs
  _            -> throwError "satisfy: condition not met or string empty"

eof :: Parser ()
eof = get >>= (<|> throwError "eof: String not empty") . guard . null

char :: Char -> Parser ()
char c = void $ satisfy (== c) <|> throwError ("char: not equal to " ++ [c])

anyChar :: Parser Char
anyChar = satisfy (const True)

digit :: Parser Int
digit = digitToInt <$> satisfy isDigit <|> throwError "digit: Not a digit"

string :: String -> Parser ()
string str = mapM_ (\c -> char c <|> throwError ("string: mismatch on char " ++ [c] ++ " in " ++ str)) str

between :: Parser left -> Parser a -> Parser right -> Parser a
between l a r = l *> a <* r

natural :: Parser Int
natural = foldl1 (\acc a -> acc * 10 + a) <$> (some (digitToInt <$> satisfy isDigit) <|> throwError "natural: number had no digits")

integer :: Parser Int
integer = maybe id (const negate) <$> optional (char '-') <*> natural

float :: Parser Double
float = do
    s <- maybe id (const negate) <$> optional (char '-')
    i <- natural
    char '.' <|> throwError "float: No digit separator"
    r <- foldr1 (\a acc -> a + acc / 10) <$> some (fromIntegral <$> digit)
    pure $ s (r / 10 + fromIntegral i)

sepBy1 :: Parser a -> Parser delim -> Parser {- nem üres -} [a]
sepBy1 p delim = (:) <$> (p <|> throwError "sepBy1: no elements")
                     <*> ((delim *> sepBy p delim) <|> pure [])

sepBy :: Parser a -> Parser delim -> Parser [a]
sepBy p delim = sepBy1 p delim <|> pure []

-- Whitespace-k elhagyása
ws :: Parser ()
ws = void $ many $ satisfy isSpace

-- Tokenizálás: whitespace-ek elhagyása
tok :: Parser a -> Parser a
tok p = p <* ws

topLevel :: Parser a -> Parser a
topLevel p = ws *> tok p <* eof

-- A tokenizált parsereket '-al szoktuk jelölni

natural' :: Parser Int
natural' = tok natural

integer' :: Parser Int
integer' = tok integer

float' :: Parser Double
float' = tok float

char' :: Char -> Parser ()
char' c = tok $ char c

string' :: String -> Parser ()
string' str = tok $ string str

rightAssoc :: (a -> a -> a) -> Parser a -> Parser sep -> Parser a
rightAssoc f p sep = chainr1 p (f <$ sep)

leftAssoc :: (a -> a -> a) -> Parser a -> Parser sep -> Parser a
leftAssoc f p sep = chainl1 p (f <$ sep)

nonAssoc :: (a -> a -> a) -> Parser a -> Parser sep -> Parser a
nonAssoc f pa psep = do
  exps <- sepBy1 pa psep
  case exps of
    [e] -> pure e
    [e1, e2] -> pure (f e1 e2)
    _ -> throwError "nonAssoc: too many or too few associations"

chainr1 :: Parser a -> Parser (a -> a -> a) -> Parser a
chainr1 v op = do
  val <- v
  ( do
      opr <- op
      res <- chainr1 v op
      pure (opr val res)
    )
    <|> pure val

chainl1 :: Parser a -> Parser (a -> a -> a) -> Parser a
chainl1 v op = v >>= parseLeft
  where
    parseLeft val =
      ( do
          opr <- op
          val2 <- v
          parseLeft (opr val val2)
      )
        <|> pure val

-- Feladat: Az óráról ismert csak számliterálokat tartalmazó nyelvet egészítsd ki a következő művelettel!

-- Legnagyobb közös osztó operátor: 
--          Beolvasása: <gcd>
--          Legyen az eddigi legerősebb operátor és asszociáljon balra!
--          Használd a beépített gcd függvényt!
--          Ez az operáció csak az egész számokra értelmezett!

-- Kifejezésnyelv
data Exp
  = IntLit Int           -- 1 2 ...
  | FloatLit Double      -- 1.0 2.11 ...
  | BoolLit Bool         -- true false
  | Var String           -- x y ...
  -- | LamLit String Exp    -- \x -> e
  | Exp :+ Exp           -- e1 + e2
  | Exp :* Exp           -- e1 * e2
  -- | Exp :- Exp           -- e1 - e2
  | Exp :/ Exp           -- e1 / e2
  | Exp :== Exp          -- e1 == e2
  -- | Exp :$ Exp           -- e1 $ e2
  | Not Exp              -- not e
  deriving (Eq, Show)

{-
+--------------------+--------------------+--------------------+
| Operátor neve      | Kötési irány       | Kötési erősség     |
+--------------------+--------------------+--------------------+
| not                | Prefix             | 20                 |
+--------------------+--------------------+--------------------+
| *                  | Jobbra             | 18                 |
+--------------------+--------------------+--------------------+
| /                  | Balra              | 16                 |
+--------------------+--------------------+--------------------+
| +                  | Jobbra             | 14                 |
+--------------------+--------------------+--------------------+
| -                  | Balra              | 12                 |
+--------------------+--------------------+--------------------+
| ==                 | Nincs              | 10                 |
+--------------------+--------------------+--------------------+
| $                  | Jobbra             | 8                  |
+--------------------+--------------------+--------------------+

-}

keywords :: [String]
keywords = ["true", "false", "not", "if", "then", "end", "while", "do"]

pNonKeyword :: Parser String
pNonKeyword = do
  res <- tok $ some (satisfy isLetter)
  res <$ (guard (res `notElem` keywords) <|> throwError "pNonKeyword: parsed a keyword")

pKeyword :: String -> Parser ()
pKeyword = string'

pAtom :: Parser Exp
pAtom = asum [
  FloatLit <$> float',
  IntLit <$> integer',
  BoolLit True <$ pKeyword "true",
  BoolLit False <$ pKeyword "false",
  -- LamLit <$> (pKeyword "lam" *> pNonKeyword) <*> (string' "->" *> pExp),
  Var <$> pNonKeyword,
  between (char' '(') pExp (char' ')')
             ] <|> throwError "pAtom: no literal, var or bracketed matches"

pNot :: Parser Exp
pNot = (Not <$> (pKeyword "not" *> pNot)) <|> pAtom

pMul :: Parser Exp
pMul = chainr1 pNot ((:*) <$ char' '*')

pDiv :: Parser Exp
pDiv = chainl1 pMul ((:/) <$ char' '/')

pAdd :: Parser Exp
pAdd = chainr1 pDiv ((:+) <$ char' '+')

-- pMinus :: Parser Exp
-- pMinus = chainl1 pAdd ((:-) <$ char' '-') -- leftAssoc (:-) pAdd (char' '-')

pEq :: Parser Exp
pEq = nonAssoc (:==) pAdd (string' "==")

-- pDollar :: Parser Exp
-- pDollar = chainr1 pEq ((:$) <$ char' '$')

pExp :: Parser Exp -- táblázat legalja
pExp = pEq

-- Állítások: értékadás, elágazások, ciklusok
data Statement
  = If Exp [Statement]        -- if e then p end
  | While Exp [Statement]     -- while e do p end
  | Assign String Exp         -- v := e

-- Írjunk ezekre parsereket!
-- Egy programkód egyes sorait ;-vel választjuk el

program :: Parser [Statement]
program = many statement

statement :: Parser Statement
statement = (sIf <|> sWhile <|> sAssign) <* char' ';'

sIf :: Parser Statement
sIf = do
  pKeyword "if"
  e <- pExp
  pKeyword "then"
  p <- program
  pKeyword "end"
  return (If e p)


sWhile :: Parser Statement
sWhile = do
  pKeyword "while"
  e <- pExp
  pKeyword "do"
  p <- program
  pKeyword "end"
  return (While e p)

sAssign :: Parser Statement
sAssign = do
  v <- pNonKeyword
  string' ":="
  e <- pExp
  return (Assign v e)

parseProgram :: String -> Either String [Statement]
parseProgram s = case runParser (topLevel program) s of
  Left e -> Left e
  Right (x,_) -> Right x

-- Interpreter
-- Kiértékelt értékek típusa:
data Val
  = VInt Int              -- int kiértékelt alakban
  | VFloat Double         -- double kiértékelt alakban
  | VBool Bool            -- bool kiértékelt alakban
  | VLam String Env Exp   -- lam kiértékelt alakban
  deriving (Show, Eq)

type Env = [(String, Val)] -- a jelenlegi környezet

data InterpreterError
  = TypeError String -- típushiba üzenettel
  | ScopeError String -- variable not in scope üzenettel
  | DivByZeroError String -- 0-val való osztás hibaüzenettel
  deriving (Show, Eq)

-- Az interpreter típusát nem adjuk meg explicit, hanem használjuk a monád transzformerek megkötéseit!
-- Értékeljünk ki egy kifejezést!
evalExp :: MonadError InterpreterError m => Exp -> Env -> m Val
evalExp (IntLit i) _ = return $ VInt i
evalExp (FloatLit f) _ = return $ VFloat f
evalExp (BoolLit b) _ = return $ VBool b
evalExp (Var s) env = case lookup s env of
  Nothing -> throwError (ScopeError $ "Variable " ++ show s ++ "not in scope")
  Just v -> return v
evalExp (e1 :+ e2) env = do
  v1 <- evalExp e1 env
  v2 <- evalExp e2 env
  case (v1, v2) of
    (VInt i1, VInt i2) -> return $ VInt (i1 + i2)
    (VFloat f1, VFloat f2) -> return $ VFloat (f1 + f2)
    _ -> throwError (TypeError "Type error for addition")
evalExp (e1 :* e2) env = do
  v1 <- evalExp e1 env
  v2 <- evalExp e2 env
  case (v1, v2) of
    (VInt i1, VInt i2) -> return $ VInt (i1 * i2)
    (VFloat f1, VFloat f2) -> return $ VFloat (f1 * f2)
    _ -> throwError (TypeError "Type error for mul")
evalExp (e1 :/ e2) env = do
  v1 <- evalExp e1 env
  v2 <- evalExp e2 env
  case (v1, v2) of
    (VInt i1, VInt i2) -> if i2 == 0 then throwError (DivByZeroError "divbyzero") else return $ VInt (div i1 i2)
    (VFloat f1, VFloat f2) -> if f2 == 0 then throwError (DivByZeroError "divbyzero") else return $ VFloat (f1 / f2)
    _ -> throwError (TypeError "Type error for mul")
evalExp (e1 :== e2) env = do
  v1 <- evalExp e1 env
  v2 <- evalExp e2 env
  case (v1, v2) of
    (VInt i1, VInt i2) -> return $ VBool (i1 == i2)
    (VFloat f1, VFloat f2) -> return $ VBool (f1 == f2)
    (VBool b1, VBool b2) -> return $ VBool (b1 == b2)
    _ -> throwError (TypeError "Type error for equals")
evalExp (Not e) env = do
  v <- evalExp e env
  case v of
    VBool b -> return $ VBool (not b)
    _ -> throwError (TypeError "Type error for not")

testEvalExp :: String -> Either InterpreterError Val
testEvalExp s = case runParser pExp s of
  Left _ ->  throwError (TypeError "Couldnt parse whole string")
  Right (e, _) -> runExcept (evalExp e [])

testGCD :: [Bool]
testGCD = [
        testEvalExp "5 <gcd> 10" == Right (VInt 5),
        testEvalExp "24 <gcd> 12 <gcd> 20" == Right (VInt 4),
        testEvalExp "5 * 2 <gcd> 8" == Right (VInt 10)
    ]



-- data Exp
--   = IntLit Int           -- 1 2 ...
--   | FloatLit Double      -- 1.0 2.11 ...
--   | BoolLit Bool         -- true false
--   | Var String           -- x y ...
--   -- | LamLit String Exp    -- \x -> e
--   | Exp :+ Exp           -- e1 + e2
--   | Exp :* Exp           -- e1 * e2
--   -- | Exp :- Exp           -- e1 - e2
--   | Exp :/ Exp           -- e1 / e2
--   | Exp :== Exp          -- e1 == e2
--   -- | Exp :$ Exp           -- e1 $ e2
--   | Not Exp              -- not e
--   deriving (Eq, Show)

-- Állítás kiértékelésénér egy state-be eltároljuk a jelenlegi környezetet
evalStatement :: (MonadError InterpreterError m, MonadState Env m) => Statement -> m ()
evalStatement (While e p) = do
  val <- evalExp e
  case val of
    VBool True -> do
      evalProgram p
      evalStatement (While e p)
    VBool False -> return ()
    _ -> throwError (TypeError "Expected booleean expresion in while loop")

evalProgram :: (MonadError InterpreterError m, MonadState Env m) => [Statement] -> m ()
evalProgram = mapM_ evalStatement

-- Egészítsük ki a nyelvet egy print állítással (hint: MonadIO megkötés)
-- Egészítsük ki a nyelvet más típusokkal (tuple, either stb)
data Exp
  = IntLit Int          
  | Var String         
  | Not Exp            
  | Print Exp           
  | Tuple [Exp]       
  | Either Exp Exp      
  deriving (Eq, Show)
data Val
  = VInt Int              
  | VBool Bool           
  | VTuple [Val]          
  | VEither Val Val      
  deriving (Show, Eq)
