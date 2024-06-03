using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadandó
{
    internal class Növény
    {
        public string név;
        public string fajta;
        public int tápanyag;

        public Növény(string name, string fajta, int tápanyag)
        {
            this.név = name;
            this.fajta = fajta;
            this.tápanyag = tápanyag;
        }
        public bool Él()
        {
            if (fajta == "p")
            {
                return (tápanyag > 0 && tápanyag <= 10);
            }
            else return tápanyag > 0;
        }
        public void TápanyagMódosító(string sug)
        {
            if (fajta == "p")
            {
                if (sug == "Alfa")
                {
                    tápanyag += 2;
                }
                else if (sug == "Delta")
                {
                    tápanyag -= 2;
                }
                else tápanyag -= 1;
            }
            else if(fajta == "d")
            {
                if (sug == "Alfa")
                {
                    tápanyag -= 3;
                }
                else if (sug == "Delta")
                {
                    tápanyag += 4;
                }
                else tápanyag -= 1;
            }
            else
            {
                if (sug == "Alfa" || sug == "Delta")
                {
                    tápanyag += 1;
                }
                else
                {
                    tápanyag -= 1;
                }
            }
        }
    }
}
