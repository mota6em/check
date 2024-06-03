using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HF7
{
    internal class Center
    {
        private List<Bank> banks;
        public Center(List<Bank> banks) 
        {
            this.banks = banks;
        }

        public int GetBalance(string cNum)
        {
            bool l;
            Bank bank;
            (l,bank) = FindBank(cNum);
            if (l)
            {
                return bank.GetBalance(cNum);
            }
            else return -1;
        }
        public void Transaction(string cNum, int amount)
        {
            bool l = false;
            Bank bank;
            (l, bank) = FindBank(cNum);
            if (l)
            {
                bank.Transaction(cNum, amount);
            }
        }

        private (bool,Bank) FindBank(string cNum)
        {
            foreach (Bank bank in banks)
            {
                bool l = bank.CheckAccount(cNum) ;
                if (l){
                    return (true, bank);
                }
            }
            return (false, null);
        }
    }
}
