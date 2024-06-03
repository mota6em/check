using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kor
{
    public class Pont
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Pont(double a, double b)
        {
            X = a; Y = b;
        }

        public double Távolság(Pont p)
        {
            return Math.Sqrt(Math.Pow(this.X - p.X, 2) + Math.Pow(this.Y - p.Y, 2));
        }
    }
}
