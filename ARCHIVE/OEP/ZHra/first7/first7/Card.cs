using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first7
{
    public class Card
    {
        public string cNum;
        private string pin;
        public Card(string cNum, String PIN)
        {
            this.cNum = cNum;
            this.pin = PIN;
        }
        public bool CheckPIN(string p)
        {
            return pin == p;
        }
        public void SetPIN(string p) { pin = p; }
    }
}
