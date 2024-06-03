using System;

namespace HF10
{
    public class Guest
    {
        private string name;
        private List<Gift> prizes;
        public Guest(string n)
        {
            this.name = n;
            prizes = new List<Gift>();
        }
        public string getName()
        {
            return name;
        }
        public void Wins(Gift g)
        {
            if (!g.targetShot.GetGifts().Contains(g))
            {
                throw new Exception("doesnt contain g");
            }
            g.targetShot.GetGifts().Remove(g);
            prizes.Add(g);
        }
        public int Result(TargetShot t)
        {
            int result = 0;
            foreach(var e in prizes)
            {
                if(e.targetShot == t)
                {
                    result += e.Value();
                }
            }
            return result;
        }
    }
}
