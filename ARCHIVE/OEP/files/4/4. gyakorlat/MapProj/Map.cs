using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._gyakorlat
{
    public class Item
    {
        public int key;
        public string data;

        public Item(int k, string s)
        {
            key = k;
            data = s;
        }
    }
    public class Map
    {
        private List<Item> seq;

        public class AlreadyInMapException() : Exception { }
        public class NotInMapException() : Exception { }

        public Map()
        {
            seq = new List<Item>();
        }

        public void SetEmpty()
        {
            seq.Clear();
        }
        public int Count()
        {
            return seq.Count;
        }
        public void Insert(Item e)
        {
            bool l = LogSearch(e.key, out int ind);
            if (l)
            {
                throw new AlreadyInMapException();
            }
            seq.Insert(ind, e);
        }
        public void Remove(int key)
        {
            bool l = LogSearch(key, out int ind);
            if (!l)
            {
                throw new NotInMapException();
            }
            seq.RemoveAt(ind);
        }
        public bool In(int key)
        {
            return LogSearch(key, out int ind);
        }
        public string this[int key]
        {
            get
            {
                bool l = LogSearch(key, out int ind);
                if (!l)
                {
                    throw new NotInMapException();
                }
                return seq[ind].data;
            }
        }

        private bool LogSearch(int key, out int ind)
        {
            ind = 0;
            bool l = false;
            int ah = 0;
            int fh = seq.Count - 1;

            while (!l && ah <= fh)
            {
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
            return l;
        }
    }
}
