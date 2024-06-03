using System;

namespace HF1
{
    public enum Content
    {
        EMPTY,
        WALL,
        TREASURE,
        GHOST
    }
    public struct Direction
    {
        public int x;
        public int y;

        public Direction(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

