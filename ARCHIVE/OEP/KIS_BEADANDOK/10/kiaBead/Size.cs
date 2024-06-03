using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF10
{
    public interface Size
    {
        int Multi();
        static Size Instance() { throw new Exception(); } // Define Instance method in the interface
    }

    public class S : Size
    {
        private static S instance = new S(); // Singleton instance for S

        public static S Instance()
        {
            return instance; // Return the singleton instance
        }
        public int Multi() { return 1; }


    }

    public class M : Size
    {
        private static M instance = new M();
        public static M Instance()
        {
            return instance ;
        }
        public int Multi() { return 2; }
    }

    public class L : Size
    {
        private static L instance = new L();
        public static L Instance()
        {
            return instance;
        }
        public int Multi() { return 3; }
    }

    public class XL : Size
    {
        private static XL instance = new XL();
        public static XL Instance()
        {
            return instance;
        }
        public int Multi() { return 4; }
    }
}
