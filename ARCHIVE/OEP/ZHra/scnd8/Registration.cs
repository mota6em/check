using System;
using System.Runtime.CompilerServices;

namespace HF8
{
    public class Registration
    {
        public Registration() { }
        public virtual int GetSize() { throw new Exception(); }
    }
    public class File : Registration
    {
        private int size;
        public File(int size)
        {
            this.size = size;
        }
        public override int GetSize()
        {
            return this.size;
        }    
    }
    public class Folder : Registration
    {
        List<Registration> items;
        public Folder() 
        {
            items = new List<Registration>();
        }
        public override int GetSize()
        {
            int size = 0;
            foreach (var item in items)
            {
                size += item.GetSize();
            }
            return size;
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