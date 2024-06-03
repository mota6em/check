using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF4
{
    public struct Element
    {
        public int pr; //{ get;  set; }
        public string data;//{ get;  set; }

        public Element(int priority, string data)
        {
            this.pr = priority;
            this.data = data;
        }
    }
}
