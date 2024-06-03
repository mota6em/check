{-# options_ghc -Wincomplete-patterns #-}
module Kiszh4 where

-- Írd meg a foldrMaybe függvényt, amely kap egy függvényt, kezdőelemet és egy listát,
-- majd a függvény segítségével összehajtogatja a listát egyetlen egy elemmé!
-- Ha az f függvény bármely meghívása Nothing-al tér vissza, legyen a végeredmény is
-- Nothing, viszont ha Just-ot ad, akkor folytassuk tovább a hajtogatást.

-- foldrMaybe :: (a -> b -> Maybe b) -> b -> [a] -> Maybe b
-- foldrMaybe _ acc [] = Just acc
-- foldrMaybe f acc (x:xs) =
--   case f x acc of
--     Nothing -> Nothing
--     Just result -> foldrMaybe f result xs


foldrMaybe :: (a -> b -> Maybe b) -> b -> [a] -> Maybe b
foldrMaybe _ acc [] = Just acc
foldrMaybe f b (a:as) = case foldrMaybe f b as of 
  Nothing -> Nothing
  Just (as') -> case f a as' of
    Nothing -> Nothing 
    Just a' -> return a' 

  
-- foldrMaybe f acc (x:xs) =
--   case f x acc of
--     Nothing -> Nothing
--     Just result -> foldrMaybe f result xs


foldrMaybe' :: (a -> b -> Maybe b) -> b -> [a] -> Maybe b
foldrMaybe' _ acc [] = Just acc
foldrMaybe' f b (a:as) = do 
  as' <- foldrMaybe' f b as 
  f a as'  


  
testF :: (Int -> Int -> Maybe Int)
testF x y 
    | x < y = Nothing
    | otherwise = Just (x + y)

tests :: [Bool]
tests = [
    foldrMaybe testF 0 [8,4,2,1,1] == Just 16,
    foldrMaybe testF 0 [7,4,2,1,1] == Nothing,
    foldrMaybe testF 0 [5,6,4,4,4,1] == Nothing,
    foldrMaybe testF 0 [] == Just 0,
    foldrMaybe testF 5 [3,2,1] == Nothing,
    foldrMaybe testF 5 [5] == Just 10
    ]