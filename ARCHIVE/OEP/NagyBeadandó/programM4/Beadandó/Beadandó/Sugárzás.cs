using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadandó
{
    internal class Sugárzás
    {
       // private int alfa_igény;
        //private int delta_igény;
        public int alfa_igény;
        public int delta_igény;
        public Sugárzás() { 
            alfa_igény = 0;
            delta_igény = 0;
        }
        public void adAlfaSug(int mennyisége) 
        {
            alfa_igény += mennyisége;
        }
        public void adDeltaSug(int mennyisége)
        {
            delta_igény += mennyisége;
        }
        public string sugMeghatározása()
        { 
            if (alfa_igény - delta_igény >= 3 )
            {
                return "Alfa";
            }        
            else if(delta_igény - alfa_igény >= 3)
            {
                return "Delta";
            }
            else
            {
                return "Nincs";
            }
        }
    }
}