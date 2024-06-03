using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF8
{
    internal class Folder
    {
        private List<Registration> items;
        public Folder()
        {
            items = new List<Registration>();
        }
        public int GetSize()
        {
            int i = 0;
            foreach(var e in items)
            {
                i += e.GetSize();
            }
            return i;
        }

        public void Add(Registration r)
        {
            items.Add(r);
        }
        public void Remove(Registration r)
        {
            items.Remove(r);
        }
    }
}
