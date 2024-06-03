using System;
using System.Reflection;
namespace HF9
{
    public class Solarsystem 
    {
        public List<Planet> planets;
        public Solarsystem()
        {
            planets = new List<Planet>();
        }
        public (bool,Starship) MaxFireP()
        {
            bool l = false;
            int max = int.MinValue;
            Starship ship = null;
            foreach(var e in planets)
            {
                bool ll = false;
                int maxx = 0;
                Starship shipp = null;
                (ll, maxx, shipp) = e.MaxFireP();
                if (ll)
                {
                    if(maxx > max)
                    {
                        max = maxx;
                        l = true;
                        ship = shipp;
                    }
                }

            }
            return (l,ship);
        }
        public List<Planet> Defenseless()
        {
            List<Planet> result = new List<Planet>();
            foreach (var e in planets)
            {
                if(e.ShipCount() == 0)
                {
                    result.Add(e);
                }              
            }
            return result;
        }
    }
}