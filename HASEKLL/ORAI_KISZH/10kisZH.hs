{-# options_ghc -Wincomplete-patterns #-}
{-# language InstanceSigs #-}

module Kiszh10 where


data MagicBox a = EmptyBox
                | SingleItem a
                | MultipleItems a (MagicBox a) (MagicBox a)
  deriving (Show)

-- A feladat: Írj ehhez a data-hoz Functor, Foldable és Traversable
--            instance-okat!

instance Functor MagicBox where
  fmap :: (a -> b) -> MagicBox a -> MagicBox b
  fmap _ EmptyBox = EmptyBox
  fmap f (SingleItem x) = SingleItem (f x)
  fmap f (MultipleItems x left right) = MultipleItems (f x) (fmap f left) (fmap f right)


instance Foldable MagicBox where
  foldMap :: Monoid m => (a -> m) -> MagicBox a -> m
  foldMap _ EmptyBox = mempty
  foldMap f (SingleItem x) = f x
  foldMap f (MultipleItems x left right) = f x <> foldMap f left <> foldMap f right


instance Traversable MagicBox where
  traverse :: Applicative f => (a -> f b) -> MagicBox a -> f (MagicBox b)
  traverse _ EmptyBox = pure EmptyBox
  traverse f (SingleItem x) = SingleItem <$> f x
  traverse f (MultipleItems x left right) = 
    MultipleItems <$> f x <*> traverse f left <*> traverse f right