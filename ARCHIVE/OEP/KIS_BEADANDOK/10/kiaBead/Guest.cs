using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF10
{
    public class Guest
    {
        private string name;
        private List<Guest> guests;
        private List<Gift> prizes;
        public Guest(string n)
        {
            this.name = n;
            prizes = new List<Gift>();
        }
        public void Wins(Gift g)
        {
            if (!g.targetShot.GetGifts().Contains(g)) { throw new Exception(); }
            g.targetShot.GetGifts().Remove(g);
            prizes.Add(g);
        }
        public int Result(TargetShot t)
        {
            int resutl = 0;
            foreach (Gift e in prizes)
            {
                if(e.targetShot == t)
                {
                    resutl += e.Value();
                }
            }
            return resutl;
        }
        public string getName(){
            return name;   }
    }
}
