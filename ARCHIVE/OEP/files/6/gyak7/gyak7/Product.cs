using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchase
{
    public class Product
    {
        public string Name { get; }
        public int Cost { get; }
        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }


    }
}