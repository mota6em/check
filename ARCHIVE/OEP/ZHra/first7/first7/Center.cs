using System;

//Done
namespace first7
{
    public class Center
    {
        private List<Bank> banks;
        public Center(List<Bank> banks) 
        {
            this.banks = banks;
        }
        public int GetBalance(String cNum)
        {
            bool l; Bank bank;
            (l,bank) = FindBank(cNum);
            if (l)
            {
                return bank.GetBalance(cNum);
            }
            return -1;
        }
        public void Transaction(String cNum,int amount)
        {
            bool l;Bank bank;
            (l,bank) = FindBank(cNum);
            if (l)
            {
                bank.Transtaction(cNum, amount);
            }
        }
        public (bool,Bank) FindBank(String cNum)
        {
            foreach(Bank bank in banks)
            {
                if (bank.CheckAccount(cNum))
                {
                    return (true, bank);
                }
            }
            return (false, null);
        }

    }
}
