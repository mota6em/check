using System;
namespace HF10
{
    public class AmPark
    {
        private List<TargetShot> targetShots;
        private List<Guest> guests;
        public AmPark(List<TargetShot> t)
        {
            if(t.Count < 2)
            {
                throw new Exception();
            }
            this.targetShots = t;
            guests = new List<Guest>();
        }
        public string Best(TargetShot t)
        {
            if(guests.Count == 0)
            {
                throw new Exception();
            }
            Guest guest = null;
            int max = int.MinValue;
            foreach(var e in guests)
            {
                if (e.Result(t) > max)
                {
                    guest = e;
                    max = e.Result(t);
                }
            }
            return guest.getName();
        }
        public void Receives(Guest g)
        {
            if (guests.Contains(g))
            {
                throw new Exception();
            }
            guests.Add(g);
        }
    }
}