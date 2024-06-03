using System;


namespace HF1
{

    public class Labirynth 
    {
        
        private int n;
        private int m;
        private Content[,] map;
            
        public Labirynth(Content[,] map )
        {
            this.map = map;
        }

        public Content WhatIsThere(int x, int y, Direction dir)
        {
            int newX = x + dir.x;
            int newY = y + dir.y;

            if (!(newX >= 0 && newX < map.GetLength(0) && newY >= 0 && newY < map.GetLength(1) && (dir.x == 0 || dir.y == 0)))
            {
                throw new IndexOutOfRangeException();
            }
            return map[newX, newY];
        }


        public void Collect(int x, int y)
        {
            if (map[x,y] != Content.TREASURE)
            {
                throw new IndexOutOfRangeException();
            }
            map[x,y] = Content.EMPTY;
        }




    }
}
