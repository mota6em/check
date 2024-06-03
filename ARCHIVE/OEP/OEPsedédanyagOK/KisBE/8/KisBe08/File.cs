using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF8
{
    public class File
    {
        private int size;
        public File(int size) 
        {
            this.size = size;
        }
        public int GetSize()
        {
            return size;
        }
    }
}
