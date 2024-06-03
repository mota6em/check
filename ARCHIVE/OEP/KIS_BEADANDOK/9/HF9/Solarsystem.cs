using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace HF9
{
    public class Solarsystem
    {
        public List<Planet> planets;

        public Solarsystem()
        {
            planets = new List<Planet>();
        }
        public (bool, Starship) MaxFireP()
        {
            bool l = false;
            int max = 0;
            Starship starship = null;
            int outMax = -1;
            Starship outShip = null;
            foreach (Planet planet in planets)
            {
                (l, max, starship) = planet.MaxFireP();

                if (l)
                {
                    if (max > outMax)
                    {
                        outMax = max;
                        outShip = starship;
                    }
                }
            }
            if(outShip != null)
            {
                return (true, outShip);
            }
            else return (false,outShip);    

        }
        public List<Planet> Defenseless()
        {
            List<Planet> retPlanets = new List<Planet>();
            foreach (Planet planet in planets)
            {
                if(planet.ShipCount() == 0)
                {
                    retPlanets.Add(planet);
                }
            }
            return retPlanets;
        }
    }
}
