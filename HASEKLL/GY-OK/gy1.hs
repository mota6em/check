module GYAK_1 where 

    xor::Bool -> Bool -> Bool
    xor = (/=)

    twelve :: Int
    twelve = let x = 3 in x + x + 3434

    f1 :: (a, (b, (c, d))) -> (b, c)
    f1 (a, (b, (c, d))) = (b, c)

    f2 :: (a -> b) -> a -> b
    f2 = ($)

    f3 :: (b -> c) -> (a -> b) -> a -> c
    f3 f g = \x -> f $ g x

    f4 :: (a -> b -> c) -> b -> a -> c
    f4 f h k = f k h 

    f5 :: ((a, b) -> c) -> (a -> (b -> c)) -- Curryzés miatt a -> b -> c == a -> (b -> c)
    f5 f x y = f (x , y)

    f6 :: (a -> b -> c) -> (a, b) -> c
    f6 f r@(a,b) = f (fst r) (snd r)

    f7 :: (a -> (b, c)) -> (a -> b, a -> c)
    f7 f = (fst . f , snd . f)

    f8 :: (a -> b, a -> c) -> (a -> (b, c))
    f8 (f , g) a = (f a, g a) 