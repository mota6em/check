using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HF1
{
    internal class Rational
    {
        private int n;
        private int d;
        public Rational(int i, int j)
        {
            if(j== 0)
            {
                throw new ArgumentException();
            }
            this.n = i;
            this.d = j;
        }
        public static Rational operator +(Rational a, Rational b)
        {
            return new Rational(a.n * b.d + a.d *b.n, a.d * b.d);
        }
        public static Rational operator -(Rational a, Rational b)
        {
            return new Rational(a.n *b.d - a.d * b.n, a.d * b.d);
        }
        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(a.n * b.n, a.d * b.d);
        }
        public static Rational operator /(Rational a, Rational b)
        {
            if(b.n == 0)
            {
                throw new DivideByZeroException();
            }
            return new Rational(a.n * b.d, a.d * b.n);
        }
        public static Rational Add(Rational a, Rational b)
        {
            return new Rational(a.n * b.d + a.d * b.n, a.d * b.d);
        }
        public static Rational Substract(Rational a, Rational b)
        {
            return new Rational(a.n * b.d - a.d * b.n, a.d * b.d);
        }
        public static Rational Multiply(Rational a, Rational b)
        {
            return new Rational(a.n * b.n, a.d * b.d);
        }
        public static Rational Divide(Rational a, Rational b)
        {
            if (b.n == 0)
            {
                throw new DivideByZeroException();
            }
            return new Rational(a.n * b.d, a.d * b.n);
        }


        public override string ToString()
        {
            return $"{n}/{d}";
        }
    }
}
