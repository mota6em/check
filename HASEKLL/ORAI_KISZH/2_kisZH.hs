{-# options_ghc -Wincomplete-patterns #-}
{-# language InstanceSigs #-}

module Kiszh2 where

-- Írd meg az Functor és Foldable instance-ét az alábbi adattípusnak:
-- deriving funkció nem használható.

data FullTree a = Leaf a | Node a (FullTree a) (FullTree a)  -- Olyan fa, ahol a csúcsokba is vannak értékek!
    deriving (Show)

instance Eq a => Eq (FullTree a) where
    -- (==) :: FullTree a -> FullTree a -> Bool
    (==) (Leaf a) (Leaf b) = a == b 
    (==) (Node a b c) (Node a' b' c') = a == a' && b == b' && c == c'
    (==) _ _ = False

-- A functortörvények betartására ügyelj! | fmap id x == x , ((fmap f). (fmap g)) x == fmap (f . g) x
instance Functor FullTree where
    -- fmap :: (a -> b) -> FullTree a -> FullTree b
    fmap f (Leaf a)  = Leaf (f a)
    fmap f (Node a b c) = Node (f a) (fmap  f b) (fmap f c)

exSkipList1 :: FullTree Int
exSkipList1 = Leaf 5

exSkipList2 :: FullTree Int
exSkipList2 = Node 3 (Leaf 4) (Leaf 5)

exSkipList3 :: FullTree Int
exSkipList3 = Node 3 (Node 9 (Leaf 4) (Leaf 5)) (Leaf 6)

exSkipList4 :: FullTree Int
exSkipList4 = Node 5 (Node 8 (Leaf 2) (Leaf 2)) (Node 7 (Leaf 2) (Leaf 4))