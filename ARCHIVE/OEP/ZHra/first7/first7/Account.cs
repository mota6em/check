using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first7
{
    public class Account
    {
        public List<Card> Cards;
        public string accNum;
        private int balance;
        public Account(String cNum)
        {
            this.Cards = new List<Card>();
            this.accNum = cNum;
            this.balance = 0;
        }
        public int GetBalance() { return balance; }
        public void Change(int a)
        {
            balance += a;
        }
    }
}
