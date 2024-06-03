{-# options_ghc -Wincomplete-patterns #-}

module Kiszh3 where

-- Írj Foldable instance-t a következő két típushoz!

data SkipList a = Skip (SkipList a) | SCons a (SkipList a) | SNill deriving (Eq, Show)

instance Foldable SkipList where
    -- foldr :: (a -> b -> b) -> b -> SkipList a ->  b
    foldr f b (SCons x xs) = f x (foldr f b xs)
    foldr f b (Skip xs) = foldr f b xs
    foldr _ b SNill = b


data CrazyType a = C1 a a | C2 a Int | C3 (CrazyType a) deriving (Eq, Show)

instance Foldable CrazyType where
    -- foldr :: (a -> b -> b) -> b -> CrazyType a -> CrazyType b 
    foldr f b (C1 x y) = f x (f y b)
    foldr f b (C2 x _) = f x b
    foldr f b (C3 c) = foldr f b c


exampleSkipList :: SkipList Int
exampleSkipList = SCons 10 (SCons 25 (SCons 17 SNill))

exampleCrazyType :: CrazyType Int
exampleCrazyType = C3 (C3 (C1 30 20))

exampleSkipList2 :: SkipList Char
exampleSkipList2 = SCons 'a' (SCons 'b' (SCons 'c' SNill))

exampleCrazyType2 :: CrazyType Char
exampleCrazyType2 = C3 (C3 (C1 'a' 'b'))

tests :: [Bool]
tests = [
    foldr (+) 0 exampleSkipList == 52,
    foldr (+) 0 exampleCrazyType == 50,
    foldr (*) 1 exampleSkipList == 4250,
    foldr (*) 1 exampleCrazyType == 600,
    foldr (:) [] exampleSkipList2 == "abc",
    foldr (:) [] exampleCrazyType2 == "ab"
    ]