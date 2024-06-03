{-# options_ghc -Wincomplete-patterns #-}
module Kiszh1 where

-- Definiáld azt a Bool -> Bool -> Bool függvényt, aminek az igazságtáblája az alábbi:

--  input|  T  |  F  |
--  -----|-----|-----|
--    T  |  F  |  F  |
--  -----|-----|-----|
--    F  |  F  |  T  |
--  -----|-----|-----|

nor :: Bool -> Bool -> Bool
nor False False = True
nor _ _ = False

-- Implementáld tetszőlegesen, de típushelyesen és teljesen az alábbi függvényt

f :: (a, (b, c)) -> (b -> d) -> d
f (a, b) f = f (fst b)