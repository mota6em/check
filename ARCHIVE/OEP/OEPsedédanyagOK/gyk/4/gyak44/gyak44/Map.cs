using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace gyak44
{

    internal class Map
    {


        private Item[] seq;
        public Map() { }
        public void SetEmpty()
        {
            seq = new Item[0];
        }
        public int Count()
        {
            return seq.Length;
        }
        public void Insert(Item e)
        {
            bool l;
            int ind;
            (l, ind) = LogSearch(e.key);
            if (l)
            {
                throw new Exception();
            }
            seq.Insert(ind, e); // // // / // 
        }
        public void Remove(int key)
        {
            bool l;
            int ind;
            (l, ind) = LogSearch(e.key);
            if (!l)
            {
                throw new Exception();
            }
            seq.Remove(ind);

        }
        public bool In(int key)
        {
            bool l;
            int ind;
            (l, ind) = LogSearch(key);
            return l;
        }
        public string this[int key]
        {
            get
            {
                (bool l, int ind) = LogSearch(key);
                if (!l)
                {
                    throw new Exception();
                }
                return seq[ind].data; 
            }
        }
        private (bool , int) LogSearch(int key)
        {
            bool l = false;
            int ah = 1;
            int fh = seq.Length;
            int ind= 0;
            while (!l && ah <= fh) {
                ind = (ah + fh) / 2;
                if (seq[ind].key > key)
                {
                    fh = ind - 1;
                }
                else if (seq[ind].key == key)
                {
                    l = true;
                }
                else if (seq[ind].key < key)
                {
                    ah = ind + 1;
                }
                    
            }
            if (!l)
            {
                ind = ah;
            }
            return (l, ind);
        }
    }

}
