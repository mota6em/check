using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenParcel
{
    public abstract class Plant
    {
        public int RipeningTime { get; }

        public Plant(int time)
        {
            RipeningTime = time;
        }

        public virtual bool IsVegetable()
        {
            return false;
        }
        public virtual bool IsFlower()
        {
            return false;
        }
    }

    public abstract class Flower : Plant
    {
        public Flower(int time) : base(time) { }

        public override bool IsFlower()
        {
            return true;
        }
    }
    public abstract class Vegetable : Plant
    {
        public Vegetable(int time) : base(time) { }

        public override bool IsVegetable()
        {
            return true;
        }
    }

    public class Tulip : Flower
    {
        private static Tulip? instance;
        private Tulip() : base(7) { }

        public static Tulip Instance()
        {
            if (instance == null)
                instance = new Tulip();
            return instance;
        }
    }

    public class Rose : Flower
    {
        private static Rose? instance;
        private Rose() : base(9) { }

        public static Rose Instance()
        {
            if (instance == null)
                instance = new Rose();
            return instance;
        }
    }

    public class Lily : Flower
    {
        private static Lily? instance;
        private Lily() : base(8) { }

        public static Lily Instance()
        {
            if (instance == null)
                instance = new Lily();
            return instance;
        }
    }

    public class Potato : Vegetable
    {
        private static Potato? instance;

        private Potato() : base(5) { }

        public static Potato Instance()
        {
            if (instance == null)
            {
                instance = new Potato();
            }
            return instance;
        }
    }

    public class Carrot : Vegetable
    {
        private static Carrot? instance;

        private Carrot() : base(7) { }

        public static Carrot Instance()
        {
            if (instance == null)
            {
                instance = new Carrot();
            }
            return instance;
        }
    }

    public class Wheat : Vegetable
    {
        private static Wheat? instance;

        private Wheat() : base(8) { }

        public static Wheat Instance()
        {
            if (instance == null)
            {
                instance = new Wheat();
            }
            return instance;
        }
    }
}
