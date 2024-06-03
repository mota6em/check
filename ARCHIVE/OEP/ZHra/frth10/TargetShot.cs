using System;

namespace HF10
{
    public class TargetShot
    {
        private List<Gift> gifts;
        private string site;
        public TargetShot(string s)
        {
            site = s;
            gifts = new List<Gift>();
        }
        public List<Gift> GetGifts()
        {
            return gifts;
        }
        public void Shows(Gift g)
        {
            if(g.targetShot!= null)
            {
                throw new Exception();
            }
            if(gifts.Contains(g) )
            {
                throw new Exception();
            }
            g.targetShot = this;
            gifts.Add(g);
        }
    }
}
