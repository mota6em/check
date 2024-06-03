using System;

namespace sampleONE
{
    public class Congressman
    {
        public Parliament parliament { get; set; }
        public string name;
        public Congressman(string n)
        {
            this.name = n;
        }
        public void Vote(bool vote,string ID)
        {
            if(parliament == null)
            {
                throw new ArgumentNullException();
            }
            parliament.Vote(this,vote, ID);
        }
    }
}
