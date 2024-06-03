using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Purchase
{
    internal class Customer
    {
       
        public string Name { get;}
        private List<string> list;
        public List<Product> basket;
        public Customer(string filename)
        {
            list = new List<string>();
            basket = new List<Product>();
            TextFileReader reader = new TextFileReader(filename);
            Name = reader.ReadString();
            if (reader.ReadString(out string str))
            {
                Name = str;
            }
            while(reader.ReadString(out str))
            {
                list.Add(str);
            }
        }
        public void Purchase(Store s)
        {
            foreach (string item in list)
            {
                (bool l, Product prod) res = Search(item, s.Foods);
                if (res.l)
                {
                    Buy(res.prod!, s.Tech);
                }
            }
            foreach (string item in list)
            {
                (bool l, Product prod) res = SearchCheap(item, s.Foods);
                if (res.l)
                {
                    Buy(res.prod!, s.Tech);
                }
            }
        }

        private (bool , Product?) SearchCheap(string name , Department department)
        {
            Product prod = department.Stock[0];
            int min;
            bool l = false;  // l = prod == null;
            foreach (Product item in department.Stock)
            {
                if (item.Name == name)
                {
                    if (l && prod.Cost > item.Cost)
                    {
                        if(prod.Cost > item.Cost)
                        {
                            prod = item;
                        }
                    }
                    else {
                        prod = item;
                        l = true;
                    }
                }
                if ((prod.Cost > item.Cost))
                {
                    prod = item;
                }
            }
            if (l) { 
                return (l, prod);
            }
            else
            {
                return (l, null);
            }
        }
        private(bool,Product) Search(string name , Department department)
        {
            foreach(Product item in department.Stock)
            {
                if ((item.Name == name))
                {
                    return (true, item);
                }
            }
            return (false, null);
        }
       private void Buy(Product pro, Department dep)
        {
            dep.Stock.Remove(pro);
            basket.Add(pro);
        }
    }
}
