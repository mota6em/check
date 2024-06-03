﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF3
{
    internal class Diag
    {    
        private double[] x;
    
        public Diag(int n)
        {
            this.x = new double[n];
        }
        public double Get(int i , int j)
        {
            if (i < 0 || i > x.Length -1 || j < 0 || j > x.Length -1)
                throw new Exception();
            if (i == j)
            {
                return x[i];
            }
            else { 
            
            } return 0.0;
        }
        public void Set(int i, int j, double e)
        {
            if (i < 0 || i > x.Length - 1 || j < 0 || j > x.Length - 1)
                throw new Exception();
            if (i == j)
            {
                x[i] = e;
            }
            else
            {
                throw new Exception();
            }
        }
        public static Diag Add(Diag a, Diag b)
        {
            if(a.x.Length != b.x.Length)
                throw new Exception();
            Diag c = new Diag(a.x.Length);
            for(int i = 0; i < a.x.Length; i++)
            {
                c.x[i] = a.x[i] + b.x[i];
            }
            return c;
        }
        public static Diag operator+(Diag a, Diag b)
        {
            if (a.x.Length != b.x.Length)
                throw new Exception();
            Diag c = new Diag(a.x.Length);
            for (int i = 0; i < a.x.Length; i++)
            {
                c.x[i] = a.x[i] + b.x[i];
            }
            return c;
        } 

        public static Diag Multiply(Diag a, Diag b)
        {
            if (a.x.Length != b.x.Length)
                throw new Exception();
            Diag c = new Diag(a.x.Length);
            for (int i = 0; i < a.x.Length; i++)
            {
                c.x[i] = a.x[i] * b.x[i];
            }
            return c;
        }
        public static Diag operator*(Diag a, Diag b)
        {
            if (a.x.Length != b.x.Length)
                throw new Exception();
            Diag c = new Diag(a.x.Length);
            for (int i = 0; i < a.x.Length; i++)
            {
                c.x[i] = a.x[i] * b.x[i];
            }
            return c;
        }
    }
}
