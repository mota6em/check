-- {-# LANGUAGE FlexibleContexts #-}
-- module KisZH6 where

-- import Control.Monad.State
-- import Control.Monad.Reader
-- import Control.Monad.Writer
-- import Control.Monad.Except

-- -- 1. feladat:

-- -- Írd meg a validateAge függvényt, ami különböző errorokat dob
-- -- a Stringben tárolt életkor alapján.
-- -- Ha üres string -> EmptyInput-ot dob
-- -- Ha nem szám -> NotAnInteger-t dob (Használd az isInteger fv-t!)
-- -- Ha negatív szám -> NegativeAge-t dob
-- -- Amúgy visszaadja az életkort

-- data InputError = EmptyInput | NotAnInteger | NegativeAge deriving (Show, Eq)


-- stringToInteger :: String -> Maybe Int
-- stringToInteger s = case reads s :: [(Int, String)] of
--     [(n, "")] -> Just n
--     _         -> Nothing

-- validateAge :: String -> Except InputError Int
-- validateAge [] = throwError EmptyInput
-- validateAge n = case stringToInteger n  of 
--     Nothing -> throwError NotAnInteger 
--     (Just a) 
--         | a< 0 -> throwError NegativeAge 
--         | otherwise -> return a 

-- tests :: [Bool]
-- tests = [runExcept (validateAge "") == Left EmptyInput,
--          runExcept (validateAge "asd") == Left NotAnInteger,
--          runExcept (validateAge "-1") == Left NegativeAge,
--          runExcept (validateAge "0") == Right 0,
--          runExcept (validateAge "1") == Right 1]


{-# language InstanceSigs, DeriveFunctor #-}

{-# options_ghc -Wincomplete-patterns #-}
module Kiszh5 where
import Control.Monad


-- State monád definíció
--------------------------------------------------------------------------------

newtype State s a = State {runState :: s -> (a, s)} deriving Functor

instance Applicative (State s) where -- Következő óra, töltelék kód
  pure  = return
  (<*>) = ap

instance Monad (State s) where
  return a = State (\s -> (a, s))
  State f >>= g = State (\s -> case f s of (a, s') -> runState (g a) s')

get :: State s s
get = State (\s -> (s, s))

put :: s -> State s ()
put s = State (\_ -> ((), s))

modify :: (s -> s) -> State s ()
modify f = do
  n <- get
  put (f n)

evalState :: State s a -> s -> a
evalState ma = fst . runState ma

execState :: State s a -> s -> s
execState ma = snd . runState ma

--------------------------------------------------------------------------------


-- Definiáld a contains metódust, mely
-- kap egy értéket, és eldönti róla, hogy benne van-e a háttérbeli állapotlistában!
-- Ne használd a beépített 'elem' függvényt!
contains :: Eq a => a -> State [a] Bool
contains n = do 
    lst <- get 
    if (isIn n lst) then 
        --put lst 
        return True 
    else 
        --put lst 
        return False 
isIn :: Eq a => a -> [a] -> Bool
-- isIn a xs = True 
isIn a [] = False 
isIn a (x:xs) 
    | (a == x) = True
    | otherwise = isIn a xs 

tests :: [Bool]
tests = [
  evalState (contains 5) [] == False,
  evalState (contains 5) [1,2,3,4] == False,
  evalState (contains 5) [1,2,3,4,5] == True,
  evalState (contains 5) [1,2,5,3,4] == True,
  evalState (contains "alma") ["korte","barack"] == False,
  evalState (contains "alma") ["alma","korte","barack"] == True
  ]