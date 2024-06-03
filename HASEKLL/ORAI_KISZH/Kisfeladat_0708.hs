{-# LANGUAGE FlexibleContexts, ConstraintKinds #-}

module KisZH0708 where

import Control.Monad.Except
import Control.Monad.Reader
import Control.Monad.State
import Control.Monad.Writer

import Control.Monad.Identity


-- Monádok:
-- State monád  - [String] : a regisztrált felhasználók nevei.
-- Reader monád -  String  : a jelenlegi felhasználó aki akar valamit csinálni
-- Writer monád - [String] : logolja ha valaki beregisztrál vagy beloginol
-- Error monád  -  String  : errorokat dob

type UserMonad m = (MonadState [String] m, MonadReader String m, MonadWriter [String] m, MonadError String m)


-- Írd meg a registerUser függvényt, ami paraméterként megkap egy új username-t
-- és a következőt csinálja:
-- felvesszük a felhasználónevek közé az új nevet és logoljuk, ha nem létezett még.
-- ha létezik már, akkor dobunk egy errort

registerUser :: UserMonad m => String -> m ()
registerUser uname = do 
    usernames <- get 
    if uname `elem` usernames
        then throwError "Exsist"
        else do 
            put (uname:usernames)
            put(usernames(filter))
registerUser username = do
    users <- get
    if username `elem` users
        then throwError "User already exists."
        else do
            modify (username :)
             putStrLn $ "User registered:" ++ username


-- Írd meg a login függvényt, ami megnézi a jelenlegi felhasználó nevét, megnézi hogy benne
-- van-e az összesben. Ha igen, logoljuk hogy bejelentkezett az adott felhasználó,
-- ha nem, dobjunk errort

login :: UserMonad m => m ()
login = do
    currentUser <- ask
    users <- get
    if currentUser `elem` users
        then  putStrLn $ "User logged in: " ++ currentUser
        else throwError "User does not exist"

-- Írd meg a deleteUser függvényt, ami kap egy felhasználó nevet, megnézi hogy
-- benne van-e az összesben. Ha igen akkor kitörlni onnan és ezt logolja.
-- Ha nem akkor errort dobunk.

-- Tipp: törléshez használd a filter függvényt
deleteUser :: UserMonad m => String -> m ()
deleteUser username = do
    users <- get
    if username `elem` users
        then do
            -- delete 
            putStrLn $ "User deletd: " ++ username
        else throwError "User does not exist."



-- Define the monad stack for the application
type TestApp = ExceptT String (WriterT [String] (ReaderT String (StateT [String] Identity)))

-- A function to run the TestApp
runTestApp :: TestApp a -> String -> [String] -> ((Either String a, [String]), [String])
runTestApp app currentUser initialState = 
    runIdentity (runStateT (runReaderT (runWriterT (runExceptT app)) currentUser) initialState)

-- A test function to demonstrate usage
test :: IO ()
test = do
    let initialState = []
        currentUser = "Alice"
        actions = do
            registerUser "Alice"
            registerUser "Bob"
            login
            deleteUser "Bob"
            login
    let ((result, log), finalState) = runTestApp actions currentUser initialState
    putStrLn "Test Results:"
    putStrLn "Final State:"
    print finalState
    putStrLn "Logs:"
    mapM_ putStrLn log
    putStrLn "Result of the TestApp:"
    case result of
        Left err -> putStrLn $ "Error: " ++ err
        Right _ -> putStrLn "Success"