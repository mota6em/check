{-# LANGUAGE FlexibleContexts #-}
module KisZH6 where

import Control.Monad.State
import Control.Monad.Reader
import Control.Monad.Writer
import Control.Monad.Except

-- 1. feladat:

-- Írd meg a validateAge függvényt, ami különböző errorokat dob
-- a Stringben tárolt életkor alapján.
-- Ha üres string -> EmptyInput-ot dob
-- Ha nem szám -> NotAnInteger-t dob (Használd az isInteger fv-t!)
-- Ha negatív szám -> NegativeAge-t dob
-- Amúgy visszaadja az életkort

data InputError = EmptyInput | NotAnInteger | NegativeAge deriving (Show, Eq)


stringToInteger :: String -> Maybe Int
stringToInteger s = case reads s :: [(Int, String)] of
    [(n, "")] -> Just n
    _         -> Nothing

validateAge :: String -> Except InputError Int
validateAge "" = throwError EmptyInput
validateAge s =
    case stringToInteger s of
        Nothing -> throwError NotAnInteger
        Just n
            | n < 0     -> throwError NegativeAge
            | otherwise -> return n

            

tests :: [Bool]
tests = [runExcept (validateAge "") == Left EmptyInput,
         runExcept (validateAge "asd") == Left NotAnInteger,
         runExcept (validateAge "-1") == Left NegativeAge,
         runExcept (validateAge "0") == Right 0,
         runExcept (validateAge "1") == Right 1]