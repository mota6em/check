using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace project0303
{
    internal class Diag
    {
        private  double[]x;
        public Diag(int n)
        {
            x = new double[n];
        }
        public double GetAt(int i, int j) {
            if (i != j)
                throw new ArgumentException("Matrix sizes are not good");
            return x[i];
        }
        public void SetAt(int i, int j, double value) {
            if (i != j)
                throw new ArgumentException("Matrix sizes are not good");
            x[i] = value;
        }
        public static Diag Mul(Diag a, Diag b)
        {
            if(a.x.Length != b.x.Length)
            {
                throw new ArgumentException("Two matrix sizes are not equals");
            }
            Diag c = new Diag(a.x.Length);
            for (int i = 0; i < a.x.Length; i++)
            {
                c.x[i] = a.x[i] * b.x[i];
            }
            return c;
        }
        public static Diag Add(Diag a, Diag b)
        {
            if (a.x.Length != b.x.Length)
            {
                throw new ArgumentException("Two matrix sizes are not equals");
            }
            Diag c = new Diag(a.x.Length);
            for (int i = 0; i < a.x.Length; i++)
            {
                c.x[i] = a.x[i] + b.x[i];
            }
            return c;
        }
        public static Diag operator+(Diag a, Diag b)
        {
            if(a.x.Length != b.x.Length)
                throw new ArgumentException("Two matrix sizes are not equals");
            Diag c = new Diag(a.x.Length);
            for (int i = 0; i < a.x.Length; i++)
            {
                c.x[i] = a.x[i] + b.x[i];
            }
            return c;
        }
        public static Diag operator*(Diag a, Diag b)
        {
            if (a.x.Length != b.x.Length)
                throw new ArgumentException("Two matrix sizes are not equals");
            Diag c = new Diag(a.x.Length);
            for (int i = 0; i < a.x.Length; i++)
            {
                c.x[i] = a.x[i] * b.x[i];
            }
            return c;
        }
        public override string ToString()
        {
            string outPut = "[ ";
            for(int i = 0; i < x.Length; i++) {
                outPut += x[i] + " ";
            }
            outPut += "]\n";
            return outPut;
        }
    }
}
