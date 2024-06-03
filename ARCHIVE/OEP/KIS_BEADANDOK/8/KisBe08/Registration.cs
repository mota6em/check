namespace HF8
{
    public class Registration
    {
        public virtual int GetSize()
        {
            throw new NotImplementedException();
        }
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
            return size;
        }
    }

    internal class Folder : Registration
    {
        private List<Registration> items;
        public Folder()
        {
            items = new List<Registration>();
        }
        public override int GetSize()
        {
            int i = 0;
            foreach (var e in items)
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
