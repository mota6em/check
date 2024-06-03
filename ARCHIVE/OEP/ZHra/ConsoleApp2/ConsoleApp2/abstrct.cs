using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public abstract class abstrct
    {
        public abstract string Name { get; set; }
        public abstrct(string name)
        {
            Name = name;
        }
    }
    public class EMber : abstrct
    {
        string name = Console.ReadLine();
        
        public EMber(string name) : base(name) { }
        public override string Name { get; set; }
        
    }
}
