using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first7
{
    public class Customer
    {
        private string pin;
        private int withdrow;
        private List<Account> accounts;
        public Customer(string pin, int withdrow)
        {
            this.pin = pin;
            this.withdrow = withdrow;
            this.accounts = new List<Account> ();
        }
        public void Withdrow(ATM atm)
        {
            atm.Process(this);
        }
        public Card ProvidesCard()
        {
            return accounts[0].Cards[0]; 
        }
        public string providesPIN()
        {
            return pin;
        }
        public int RequestMoney()
        {
            return withdrow;

        }
        public void AddAccount(Account a)
        {
            accounts.Add(a);
        }
    }
}
