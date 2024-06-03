using System;

namespace first7
{
    public class Bank
    {
        private List<Account> accounts;
        public Bank()
        {
            accounts = new List<Account>();
        }
        public void OpenAccount(String cNum, Customer c)
        {
            Account account = new Account(cNum);
            c.AddAccount(account);
            accounts.Add(account);
        }
        public void ProvidesCard(String cNum)
        {
            Card card = new Card(cNum,"1234");
            foreach(Account account in accounts)
            {
                if(account.accNum == cNum)
                {
                    account.Cards.Add(card);
                }
            }

        }
        public int GetBalance(String cNum)
        {
            bool l; Account account;
            (l, account) = findAccount(cNum);
            if (l)
            {
                return account.GetBalance();
            }
            return -1;
        }

        public void Transtaction(String cNum,int amount)
        {
            bool l;Account account;
            (l,account) = findAccount(cNum);
            if (l)
            {
                account.Change(amount);
            }
        }
        public bool CheckAccount(String cNum)
        {
            bool l;
            foreach(var account in accounts)
            {
                if(account.accNum == cNum)
                {
                    return true;
                }
                
            }return false;
        }
        //laseone
        private (bool,Account) findAccount(String cNum)
        {
            foreach (var account in accounts)
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