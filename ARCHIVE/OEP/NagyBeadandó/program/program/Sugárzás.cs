using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    public abstract class Sugárzás
    {
        protected int alfa_igény;
        protected int delta_igény;
        public abstract void változik(Puffancs növény);
        public abstract void változik(Deltafa növény);
        public abstract void változik(Parabokor növény);

        public int getAlfaIgény()
        {
            return alfa_igény;
        }
        public int getDeltaIgény()
        {
            return delta_igény;
        }
        public Sugárzás(int a, int d)
        {
            this.alfa_igény = a;
            this.delta_igény = d;
        }
    }
    public class AlfaSugárzás : Sugárzás
    {

        public AlfaSugárzás(int a, int d) : base(a, d) { }
        public override void változik(Puffancs növény)
        {
            növény.TápmennyiMódosító(2);
            this.alfa_igény += 10;
        }
        public override void változik(Deltafa növény)
        {
            növény.TápmennyiMódosító(-3);
            if (növény.getTápmennyi() < 5 && növény.getTápmennyi() > 0)
            {
                this.delta_igény += 4;
            }
            else if (növény.getTápmennyi() <= 10 && növény.getTápmennyi() >= 5)
            {
                this.delta_igény += 1;
            }
        }
        public override void változik(Parabokor növény)
        {

            növény.TápmennyiMódosító(1);

        }
        public override string ToString()
        {
            return "Alfa";
        }
    }



    public class DeltaSugárzás : Sugárzás
    {
        public DeltaSugárzás(int a, int d) : base(a, d) { }

        public override void változik(Puffancs növény)
        {
            növény.TápmennyiMódosító(-2);
            this.alfa_igény += 10;
        }
        public override void változik(Deltafa növény)
        {
          
                növény.TápmennyiMódosító(4);
                if (növény.getTápmennyi() < 5 && növény.getTápmennyi() > 0)
                {
                    this.delta_igény += 4;
                }
                else if (növény.getTápmennyi() <= 10 && növény.getTápmennyi() >= 5)
                {
                    this.delta_igény += 1;
                }
        }
        public override void változik(Parabokor növény)
        {
           
                növény.TápmennyiMódosító(1);
   
        }
        public override string ToString()
        {
            return "Delta";
        }
    }

    public class NincsSugárzás : Sugárzás
    {

        public NincsSugárzás(int a, int d) : base(a, d) { }

        public override void változik(Puffancs növény)
        {
            növény.TápmennyiMódosító(-1);
            this.alfa_igény += 10;
        }
        public override void változik(Deltafa növény)
        {
                növény.TápmennyiMódosító(-1);
                if (növény.getTápmennyi() < 5 && növény.getTápmennyi() > 0)
                {
                    this.delta_igény += 4;
                }
                else if (növény.getTápmennyi() <= 10 && növény.getTápmennyi() >= 5)
                {
                    this.delta_igény += 1;
                }
        }
        public override void változik(Parabokor növény)
        {
                növény.TápmennyiMódosító(-1);
            
        }
        public override string ToString()
        {
            return "Nincs";
        }
    }
}
