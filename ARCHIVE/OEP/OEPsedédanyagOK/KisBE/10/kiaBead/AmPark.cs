using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF10
{
    public class AmPark
    {
        private List<TargetShot> targetShots;
        private List<Guest> guests;
        public AmPark(List<TargetShot> t)
        {
            if(t.Count < 2) { throw new Exception(); }
            this.targetShots = t;
            guests = new List<Guest>();
        }
        public  string Best(TargetShot g)
        {
            if(guests.Count == 0) { throw new Exception(); }
            int max = -2;
            string res = string.Empty;
            foreach(Guest e in guests)
            {
                if(e.Result(g) > max)
                {
                    max = e.Result(g);
                    res = e.getName();
                }
            }
            return res; 
        }
        public void Receives(Guest g)
        {
            if (guests.Contains(g)) { throw new Exception(); }
            guests.Add(g);
        }
    }
}
