using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP
{

    internal class Asszomb
    {
        public Elem[] e;
        public Asszomb(int n)
        {
            e = new Elem[n];
        }
        public bool IsEmpty()
        {
            return e.Length == 0;
        }
        public void SetEmpty()
        {
            e = new Elem[0];
        }
        public string GetAt(int k)
        {
            bool l; int ind;
            (l,ind) = LogSearch(k);
            if (!l) 
            {
                throw new Exception();
            }
            return e[ind].v;
        }
        public void SetAt(int k, string v)
        {
            bool l;
            int ind;
            ( l,ind) = LogSearch(k);
            if (l)
            {
                throw new Exception();
            }
            Elem[] temp_e = new Elem[e.Length + 1];
            for(int i= 0; i<temp_e.Length; i++)
            {
                if(i < ind)
                {
                    temp_e[i] = e[i];
                }
                else if(i == ind)
                {
                    temp_e[ind].key = k;
                    temp_e[ind].v = v;
                }
                else
                {
                    temp_e[i] = e[i - 1];
                }
            }
            e = new Elem[e.Length + 1];
            e = temp_e;
        }
        public bool IsIn(int k)
        {
            bool l = false;
            int ind;
            (l, ind) = LogSearch(k);
            return l;
        }
        public void RemoveAt(int k)
        {
            bool l;
            int ind;
            (l, ind) = LogSearch(k);
            if (l)
            {
                throw new Exception();
            }
            Elem[] temp_e = new Elem[e.Length - 1];
            for (int i = 0; i < temp_e.Length; i++)
            {
                if (i < ind)
                {
                    temp_e[i] = e[i];
                }
                else
                {
                    temp_e[i] = e[i + 1];
                }
            }
            e = new Elem[e.Length - 1];
            e = temp_e;
        }

        public int Count()
        {
            return e.Length;
        }
        private (bool, int) LogSearch(int k)
        {
            int ind = 0;
            bool l = false;
            int ah = 0;
            int fh = e.Length - 1;
            while(!l && ah<= fh)
            {
                ind = (ah + fh)/ 2;
                if (e[ind].key < k)
                {
                    fh = ind - 1;
                }
                else if (e[ind].key > k)
                {
                    fh = ind + 1; 
                }
                else
                {
                    l = true;
                }
            }
            if (!l)
            {
                ind = ah;
            }
            return (l, ind);
        }
        /*private (bool,int) LogSearch(int k)
        {
            bool l = false;
            int ah = 0;
            int fh = e.Length-1;
            int ind = (ah + fh) /2;
            if(e.Length ==  0) 
            {
                //throw new Exception(); 
                return (l, ind);
            }
            while(!l  e[ind].key != k)
            {
                if (e[ind].key > k)
                {
                    ind = ind - 1;
                }
                else if (e[ind].key < k)
                {
                    ind = ind + 1;
                }
                else
                {
                    l = true;
                }
            }
            return (l, ind);
        }*/
        public override string ToString()
        {
            string output = "<";
            for(int i = 0; i < e.Length; i++)
            {
                output += (e[i].key + ", " + e[i].v + " | ") ;
            }
            output += ">";
            return output;

        }
    }
}
