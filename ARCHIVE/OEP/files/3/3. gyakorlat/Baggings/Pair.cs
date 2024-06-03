using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baggings
{
    public class Pair
    {
        public string data;
        public int count;

        public Pair(string data, int count)
        {
            this.data = data;
            this.count = count;
        }

        public override string ToString()
        {
            return "(" + data + ", " + count + ")";
        }
    }
}
