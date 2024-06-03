using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF9
{
    public class Planet
    {
        public string name;
        private List<Starship> ships;
        
        public Planet(string name)
        {
            ships = new List<Starship>();
            this.name = name;
        }
        public void Defends(Starship s)
        {
            if (ships.Contains(s))
            {
                throw new Exception();
            }
            ships.Add(s);
        }
        public void Leaves(Starship s)
        {
            if(!ships.Contains(s))
            {
                throw new Exception();
            }
            ships.Remove(s);
        }
        public int ShipCount() { return ships.Count; }
        public int ShieldSum()
        {
            int sum = 0;
            foreach(Starship s in ships)
            {
                sum += s.GetShield();
            }
            return sum;
        }
        public (bool,int, Starship) MaxFireP() //not sure here
        {
            Starship s = null;
            int max = -1;
            foreach(Starship e in ships)
            {
                if(e.FireP() > max)
                {
                    s = e;
                    max = e.FireP();
                }
            }
            if(s == null)
            {
                return (false, 0, s);
            }
            else
            {
                return (true, max,  s);
            }
        }
    }
}
