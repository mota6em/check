using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3F_Vektor
{
    public class Vector
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }


        //Static kulcsszó: a metódust egy "osztályszintű" metódussá alakítja, nem lesz egy konkrét objektumhoz kötve
        //Osztályszintű metódusok felhasználása esetén elég a metódusra és az osztályára hivatkozni: <osztálynév>.<metódusnév>(<paraméterek>) Note: 2. gyakorlaton majd nézünk ilyet
        //Az operátorok esetén ez nyilván alakilag máshogy néz ki, lásd egy szimpla összeadásnál: 1+1 (nem pedig mondjuk int eredmény = int.Plus(1,1)
        public static Vector operator +(Vector left, Vector right)
        {
            return new Vector(left.X + right.X, left.Y + right.Y);
        }

        public static double operator *(Vector left, Vector right)
        {
            return left.X * right.X + left.Y * right.Y;
        }
    }
}
