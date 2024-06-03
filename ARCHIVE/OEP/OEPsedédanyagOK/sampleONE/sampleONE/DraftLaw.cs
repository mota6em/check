using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sampleONE
{
    public abstract class DraftLaw
    {
        public Parliament parliament { get; set; }
        public string date;
        public string ID;
        public List<bool> votes;
        protected DraftLaw(string d,string id)
        {
            date = d;
            ID = id;
            votes = new List<bool>();
            parliament = null;
        }
        public string ToString()
        {
            return ID+" ";
        }
        protected int YesCount()
        {
            int n = 0;
            foreach (bool e in votes)
            {
                if (e==true) { n++; }
            }
            return n;   
        }
        public virtual bool IsValid() { throw new Exception(); }
    }
    public class Normal : DraftLaw
    {
        public Normal(string d, string id) : base(d,id){ }
        public override bool IsValid()
        {
            return true;
            return (YesCount() * 2 > votes.Count);
        }
    }
    public class Cardinal : DraftLaw
    {
        public Cardinal(string d, string ID) : base(d,ID) { }
        public override bool IsValid()
        {
            if (parliament == null) { return false; }
            return YesCount() * 2 > parliament.cmen.Count;
        }
    }
    public class Constitutional : DraftLaw
    {
        public Constitutional(string d, string id) : base (d,id) { }
        public override bool IsValid()
        {
            if(parliament == null || parliament.cmen.Count == 0) return false;
            return YesCount() * 3 >= parliament.cmen.Count * 2;
        }
    }
}
