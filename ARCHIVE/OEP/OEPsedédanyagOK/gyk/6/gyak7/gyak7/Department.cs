using Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchase
{
    internal class Department
    {
        public List<Product> Stock;
        public Department()
        {
            Stock = new List<Product>();
        }
    }
}
