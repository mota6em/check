using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sampleONE
{
    public class MissingMemberException : Exception;
    public class Parliament
    {
        public List<Congressman> cmen = new List<Congressman>();
        public List<DraftLaw> laws;
        public Parliament(List<Congressman> cm)
        {
            foreach(var c in cm)
            {
                c.parliament = this;
                if (!cmen.Contains(c))
                {
                    cmen.Add(c);
                }
            }
        }
        public void Submit(DraftLaw d)
        {
            bool l = false;
            foreach(var e in laws)
            {
                if (e.ID == d.ID)
                {
                    l = true;
                }
            }
            if (l)
            {
                throw new ArgumentException();
            }
            d.parliament = this;
        }
        
        public void Vote(Congressman cm, bool b, string ID)
        {
            bool l = false;
            DraftLaw elem = null;
            foreach(var e in laws)
            {
                if (e.ID == ID)
                {
                    l = true;
                    elem = e;
                }
            }
            if (!l)
            {
                throw new MissingMemberException();
            }
            if (elem.parliament.cmen.Contains(cm))
            {
                throw new ArgumentException();
            }
            elem.parliament.cmen.Add(cm);
            elem.votes.Add(b);
        }
        public List<string> ValidLaws()
        {
            List<string> result = new List<string>();
            foreach(var t in laws)
            {
                if(t.IsValid())
                {
                    result.Add(t.ID);
                }
            }
            return result;
        }
    }
}
