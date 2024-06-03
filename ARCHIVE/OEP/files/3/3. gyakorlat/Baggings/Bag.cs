using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baggings
{
    public class Bag
    {
        #region Basic
        private int maxind;
        private List<Pair> seq;

        public class EmptyBagException : Exception { }

        public Bag()
        {
            seq = new List<Pair>();
        }
        #endregion

        #region Public Methods
        public void SetEmpty()
        {
            seq.Clear();
            //seq = new List<Pair>();
        }
        public bool Empty()
        {
            return seq.Count == 0;
        }
        public int Multiple(string e)
        {
            bool l = LogSearch(e, out int ind);
            if (l)
            {
                return seq[ind].count;
            } else
            {
                return 0;
            }
        }
        public string Max()
        {
            if (seq.Count > 0)
            {
                return seq[maxind].data;
            }
            throw new EmptyBagException();
        }
        public void Insert(string e)
        {
            bool l = LogSearch(e, out int ind);
            if (l)
            {
                ++seq[ind].count;
                if (seq[ind].count > seq[maxind].count)
                {
                    maxind = ind;
                }
            } else
            {
                seq.Insert(ind, new Pair(e, 1));
                if (seq[ind].count == 1)
                {
                    maxind = 0;
                } else if (maxind > ind)
                {
                    ++maxind;
                }
            }
        }
        public void Remove(string e)
        {
            bool l = LogSearch(e, out int ind);
            if (l)
            {
                if (seq[ind].count > 1)
                {
                    --seq[ind].count;
                } else if (seq[ind].count == 1)
                {
                    seq.RemoveAt(ind);
                }

                if (seq[ind].count > 0)
                {
                    MaxSearch();
                }
            }
        }
        public override string ToString()
        {
            string output = "[";
            foreach (Pair pair in seq)
            {
                output += pair.ToString();
            }
            output += "]";
            return output;
        }
        #endregion

        #region Private Methods
        private bool LogSearch(string e, out int ind)
        {
            ind = 0;
            bool l = false;
            int ah = 0;
            int fh = seq.Count - 1;

            while (!l && ah <= fh)
            {
                ind = (ah + fh) / 2;
                if (string.Compare(seq[ind].data, e) > 0)
                {
                    fh = ind - 1;
                } else if (string.Compare(seq[ind].data, e) == 0)
                {
                    l = true;
                } else if (string.Compare(seq[ind].data, e) < 0)
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
        private void MaxSearch()
        {
            maxind = 0;
            int max = seq[0].count;
            for (int i = 0; i < seq.Count; i++)
            {
                if (seq[i].count > max)
                {
                    max = seq[i].count;
                    maxind = i;
                }
            }
        }
        #endregion
    }
}
