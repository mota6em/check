using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF7
{
    internal class Customer
    {
        private string pin;
        private int withdraw;
        private List<Account> accounts;  
        public Customer(string PIN, int pénzmennyiség)
        {
            this.pin = PIN;
            this.withdraw = pénzmennyiség;
            accounts = new List<Account>();
        }
        public void Withdrawal(ATM atm)
        {
            atm.Process(this);
        }
        public Card ProvidesCard()
        {
            if (accounts.Count > 0 && accounts[0].cards.Count > 0)
            {
                return accounts[0].cards[0];
            }
            else
            {
                return null; 
            }
        }

        public string ProvidesPIN()
        {
            return pin;
        }
        public int RequestMoney()
        {
            return withdraw;
        }
        public void AddAccount(Account a)
        {
            accounts.Add(a);
        }
    }
}
