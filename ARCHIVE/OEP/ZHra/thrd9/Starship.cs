using System;
namespace HF9
{
    public class Starship
    {
        private string name;
        protected int shield;
        protected int armor;
        protected int guardian;
        private Planet planet;
        public Starship(string name, int shiled, int aromor, int guardian)
        {
            this.name = name;
            this.shield = shiled;
            this.armor = aromor;
            this.guardian = guardian;
            planet = null;
        }
        public int GetShield()
        {
            return shield;
        }
        public void StaysAtPlanet(Planet p)
        {
            if (planet != null)
            {
                planet.Leaves(this);
            }
            planet = p;
            planet.Defends(this);
        }
        public void LeavesPlanet()
        {
            if (planet == null)
            {
                throw new Exception();
            }
            planet.Leaves(this);
            planet = null;
        }
        public virtual int FireP() { throw new Exception(); }
    }
    public class Wallbreaker : Starship
    {
        public Wallbreaker(string name, int shiled, int aromor, int guardian) : base(name, shiled, aromor, guardian) { }
        public override int FireP()
        {
            return armor / 2;
        }
    }
    public class Landingship : Starship
    {
        public Landingship(string name, int shiled, int armor, int guardian) : base(name, shiled, armor, guardian) { }
        public override int FireP()
        {
            return guardian;
        }
    }
    public class Lasership : Starship
    {
        public Lasership(string name, int shiled, int aromor, int guardian) : base(name, shiled, aromor, guardian) { }
        public override int FireP()
        {
            return shield;
        }
    }
}