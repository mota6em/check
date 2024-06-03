using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komplex
{
    public class Komplex
    {
        /* public double re { get; private set; }
         public double im { get; private set; }
        */
        private double re;
        private double im;
        public Komplex(double a, double b)
        {
            re = a;
            im = b;
        }

        public static Komplex operator +(Komplex a, Komplex b)
        {
            return new Komplex(a.re + b.re, a.im + b.im);
        }

        public static Komplex operator -(Komplex a, Komplex b)
        {
            return new Komplex(a.re - b.re, a.im - b.im);
        }

        public static Komplex operator *(Komplex a, Komplex b)
        {
            return new Komplex(a.re * b.re - a.im * b.im, a.re * b.im + a.im * b.re);
        }

        public static Komplex operator /(Komplex a, Komplex b)
        {
            if (b.re == 0 && b.im == 0)
            {
                throw new DivideByZeroException();
            }

            return new Komplex(
                (a.re * b.re + a.im * b.im) / (Math.Pow(b.re, 2) + Math.Pow(b.im, 2)),
                (a.re * b.im - a.im * b.re) / (Math.Pow(b.re, 2) + Math.Pow(b.im, 2))
                );
        }

        public override string ToString()
        {
            return $"{re} + {im}i";
        }
    }
}
