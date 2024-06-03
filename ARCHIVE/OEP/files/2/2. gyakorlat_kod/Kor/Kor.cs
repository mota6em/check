using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kor
{
    public class Kor
    {
        private Pont c;
        private double r;

        public class NegativeRadiusException : Exception { }

        public Kor(Pont p, double a)
        {
            if (a < 0)
            {
                throw new NegativeRadiusException();
            }

            c = p;
            r = a;
        }

        public bool Tartalmaz(Pont p)
        {
            return c.Távolság(p) <= r;
        }
    }
}
