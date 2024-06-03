using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HF4
{
    public class PrQueue
    {
        private Element[] seq;
        public PrQueue()
        {
            seq = new Element[0];
        }
        public void SetEmpty() { seq = new Element[0]; }
        public bool isEmpty() { return seq.Length == 0;}
        public void Add(Element e)
        {
            Element[] temp_seq = new Element[seq.Length+1];
            for(int i  = 0; i < seq.Length; i++)
            {
                temp_seq[i] = seq[i];
            }
            temp_seq[seq.Length] = e;
            seq = temp_seq;
        }
        public Element GetMax()
        {
            if (seq.Length == 0)
            {
                throw new Exception();
            }
            int max, ind;
            (max, ind) = MaxSelect();
            return seq[ind];
        }

        public Element RemMax()
        {
            if (seq.Length == 0)
            {
                throw new Exception();
            }
            int max, ind;
            (max, ind) = MaxSelect();
            Element e = new Element();
            e = seq[ind];


                    //pop_back
             Element[] temp_array = new Element[seq.Length - 1];
             for (int i = 0; i < ind; i++)
             {
                 temp_array[i] = seq[i];
             }
             for (int i = ind; i < seq.Length - 1; i++)
             {
                 temp_array[i] = seq[i + 1];
             }
             seq = temp_array;
             
            return e;
        }
        private (int,int) MaxSelect()
        {
            if(seq.Length == 0)
            {
                throw new Exception();
            }
            int ind = 0;
            int max;
            max = seq[0].pr;
            for (int i = 1; i < seq.Length; i++)
            {
                if (seq[i].pr > max)
                {
                    ind = i;
                    max = seq[i].pr;
                }
            }
            return (max, ind);
        }
    } 
}
