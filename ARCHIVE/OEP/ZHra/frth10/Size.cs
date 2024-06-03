using System;

namespace HF10
{
    public interface Size
    {
        public abstract int Multi();
        static Size Instance() { throw new Exception(); }
    }
    public class S : Size
    {
        public S () : base(){}
        private static S instance = new S();
        public static S Instance()
        {
            return instance;
        }
        public int Multi()
        {
            return 1;
        }
    }
    public class M : Size
    {
        public M() : base() { }
        public int Multi()
        {
            return 2;
        }
        private static M instance = new M();
        public static M Instance()
        {
            return instance;
        }
    }
    public class L : Size
    {
        public L() : base() { }
        public int Multi()
        {
            return 3;
        }
        private static L instance = new L();
        public static L Instance()
        {
            return instance;
        }
    }
    public class XL : Size
    {
        public XL() : base() { }
        public int Multi()
        {
            return 4;
        }
        private static XL instance = new XL();
        public static XL Instance()
        {
            return instance;
        }
    }
}
