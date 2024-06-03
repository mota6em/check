using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polinom
{
    public class Poli
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public Poli(double x, double y, double z)
        {
            A = x;
            B = y;
            C = z;
        }

        public double Value(double x)
        {
            return A * Math.Pow(x, 2) + B * x + C;
        }

        public static Poli operator +(Poli left, Poli right)
        {
            return new Poli(left.A + right.A, left.B + right.B, left.C + right.C);
        }
        public static Poli operator -(Poli left, Poli right)
        {
            return new Poli(left.A - right.A, left.B - right.B, left.C - right.C);
        }
        public static Poli operator *(Poli left, double right)
        {
            return new Poli(left.A * right, left.B * right, left.C * right);
        }
    }
}
