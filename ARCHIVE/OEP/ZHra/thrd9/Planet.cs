using System;
using System.Runtime.InteropServices;
namespace HF9
{
    public class Planet
    {
        private List<Starship> ships;
        public string name;
        public Planet(string name)
        {
            this.name = name;
            ships = new List<Starship>();
        }
        public void Defends(Starship starship)
        {
            if(ships.Contains(starship))
            {
                throw new Exception();
            }
            ships.Add(starship);
        }
        public void Leaves(Starship starship)
        {
            if(!ships.Contains(starship))
            {
                throw new Exception();
            }
            ships.Remove(starship);
        }
        public int ShipCount()
        {
            return ships.Count;
        }
        public int ShieldSum()
        {
            int sum = 0;
            foreach (var e in ships)
            {
                sum += e.GetShield();
            }
            return sum;
        }
        public (bool, int, Starship) MaxFireP()
        {
            bool l = false;
            int max= int.MinValue;
            Starship ship = null;
            foreach(var e in ships)
            {
                if(e.FireP() > max)
                {
                    max = e.FireP();
                    ship = e;
                    l = true;
                }
            }
            if (l)
            {
                return (l, max, ship);
            }
            return (l, -1, null);
        }
    }
}