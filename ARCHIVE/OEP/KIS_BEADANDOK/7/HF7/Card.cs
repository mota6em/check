using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF7
{
    internal class Card
    {
        public string cNum;
        private string pin;

        public Card(string cNum, string PIN) 
        {
            this.cNum = cNum;
            this.pin = PIN;
        }
        public void SetPIN(string p)
        {
            this.pin = p;
        }
        public bool CheckPIN(string p)
        {
            return pin == p;
        }
    }
}
