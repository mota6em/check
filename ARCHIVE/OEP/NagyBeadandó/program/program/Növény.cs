using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    public abstract class Növény
    {
        private string név;
        protected int tápMennyi;

        public Növény(string név, int tápMennyi)
        {
            this.név = név;
            this.tápMennyi = tápMennyi;
        }
        public abstract bool Él();
        public abstract void Kölcsönhatás(Sugárzás sug);

        public string getNév()
        {
            return név;
        }
        public void TápmennyiMódosító(int n)
        {
            if(tápMennyi + n <= 0)
            {
                tápMennyi = 0;
            }
            else
            {
                tápMennyi = tápMennyi + n;
            }
        }
        public int getTápmennyi()
        {
            return tápMennyi;
        }
    }

    public class Parabokor : Növény
    {
        public Parabokor(string név, int tápMennyi) : base(név, tápMennyi) { }
        public override bool Él()
        {
            return (tápMennyi > 0);
        }
        public override void Kölcsönhatás(Sugárzás sug)
        {
            sug.változik(this);
        }
        public override string ToString()
        {
            return "Parabokor";
        }
    }

    public class Deltafa : Növény
    {
        public Deltafa(string név, int tápMennyi) : base(név, tápMennyi) { }
        public override bool Él()
        {
            return (tápMennyi > 0);
        }
        public override void Kölcsönhatás(Sugárzás sug)
        {
            sug.változik(this);

        }
        public override string ToString()
        {
            return "Deltafa";
        }
    }
    public class Puffancs : Növény
    {
        public Puffancs(string név, int tápMennyi) : base(név, tápMennyi) { }
        public override bool Él()
        {
            return (tápMennyi > 0 && tápMennyi <= 10); //A feladat alapján ez a növényfajta elpusztul, ha a tápanyagmennyiség meghaladja a 10-et. 
        }
        public override void Kölcsönhatás(Sugárzás sug)
        {
            sug.változik(this);
        }
        public override string ToString()
        {
            return "Puffancs";
        }
    }
}
