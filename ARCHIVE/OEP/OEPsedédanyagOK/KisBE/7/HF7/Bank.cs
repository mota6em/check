using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HF7
{
    internal class Bank
    {
        private List<Account> accounts;
        public Bank()
        {
            accounts = new List<Account>();
        }
        public void OpenAccount(string cNum, Customer c)
        {
            Account account = new Account(cNum);
            c.AddAccount(account);
            accounts.Add(account);
        }
        public void ProvidesCard(string cNum)
        {
            foreach (var account in accounts)
            {
                if (account.accNum == cNum)
                {
                    Card card = new Card(cNum , "1234");
                    account.cards.Add(card);
                }
            }
        }
        public int GetBalance(string cNum)
        {
            bool l = false;
            Account account;
            (l,account) = FindAccount(cNum);
            if (l)
            {
                return account.GetBalance();
            }
            else { return -1; }
        }
        public void Transaction(string cNum, int amount)
        {
            bool l = false;
            Account account;
            (l, account) = FindAccount(cNum);
            if (l)
            {
                account.Change(amount);
            }
        }
        public bool CheckAccount(string cNum)
        {
            bool l = false;
            foreach (var account in accounts)
            {
                if(account.accNum == cNum)
                {
                    l = true;
                    return true;
                }
            }
            return false;
        }
        private (bool, Account) FindAccount(string cNum) // why this is not woriking will and everytime retun false null
        {
            foreach (Account account in accounts)
            {
                if (account.accNum == cNum)
                {
                    return (true, account);
                }
            }
            return (false, null);
        }

    }
}
