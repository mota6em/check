using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HF9
{
    public class Starship
    {
        private string name;
        protected int shied;
        protected int armor;
        protected int guardian;
        private Planet planet;
        public Starship(string name, int shied, int armor, int guardian)
        {
            this.name = name;
            this.shied = shied;
            this.armor = armor;
            this.guardian = guardian;
            planet = null;
        }
        public int GetShield() { return shied; }
        public void StaysAtPlanet(Planet p)
        {
            if(planet != null)
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
        public virtual int FireP()
        {
            throw new NotImplementedException();
        }
    }

    public class Wallbreaker : Starship
    {
        public Wallbreaker(string name, int shied, int armor, int guardian)
            : base(name, shied, armor, guardian)  {}

        public override int FireP()
        {
            return armor/2;
        }
    }
    public class Landingship : Starship
    {
        public Landingship(string name, int shied, int armor, int guardian) : base(name, shied, armor, guardian) { }

        public override int FireP()
        {
            return guardian;
        }
    }
    public class Lasership : Starship
    {
        public Lasership(string name, int shied, int armor, int guardian) : base(name, shied, armor,guardian) { }

        public override int FireP()
        {
            return shied;
        }
    }

}
