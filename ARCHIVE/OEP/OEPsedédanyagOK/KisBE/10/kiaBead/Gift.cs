using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF10
{
    public class Gift
    {
        //todo
        public TargetShot targetShot;
        private Size size;
        public Gift(Size s)
        {
            this.size = s;
        }
        public int Value() { return Point() * size.Multi(); }
        public virtual int Point() { return 0; }

    }
    public class Ball : Gift
    {
        public Ball(Size s) : base(s){ }
        public override int Point()
        {
            return 1;
        }
    }
    public class Figure : Gift
    {
        public Figure(Size s) : base(s) { }
        public override int Point()
        {
            return 2;
        }

    }
    public class Plush : Gift
    {
        public Plush(Size s) : base(s) { }
        public override int Point()
        {
            return 3;
        }
    }
}
