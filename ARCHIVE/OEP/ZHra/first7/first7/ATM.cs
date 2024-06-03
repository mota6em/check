using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first7
{
    public class ATM
    {
        private Center center;
        public string site;
        public ATM(string s, Center center)
        {
            this.site = s;
            this.center = center;
        }
        public void Process(Customer c)
        {
            //wait... or check after finish
            Card card = c.ProvidesCard();
            if (card.CheckPIN(c.providesPIN()))
            {
                int a = c.RequestMoney();
                if (center.GetBalance(card.cNum) >= a)
                {
                    center.Transaction(card.cNum, -a);
                }
            }
        }
    }
}
