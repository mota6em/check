using System;
namespace sampleONE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine();
            List<Congressman> cmen = new List<Congressman>();
            string[] cmenNames = line.Split(" ");
            for(int i = 0; i < cmenNames.Length; i += 2)
            {
                string s = cmenNames[i] +" "+ cmenNames[i+1];
                Congressman cman = new Congressman(s);
                cmen.Add(cman);
            }
            List<DraftLaw> draftLaws = new List<DraftLaw>();
            Parliament parliament =new Parliament(cmen);

            while(!string.IsNullOrEmpty(line =Console.ReadLine()))
            {
                DraftLaw law = null;
                string[] data = line.Split(" ");
                if (data[0] is Normal)
                {
                    law = new Normal(data[2], data[1]);
                }
                else if (data[0] is Constitutional)
                {
                    law = new Constitutional(data[2], data[1]);
                }
                else
                {
                    law = new Cardinal(data[2], data[1]);
                }
                for (int i = 3; i < data.Length; i++)
                {
                    if (data[i] == "yes")
                    {
                        law.votes.Add(true);
                    }
                    else if (data[i] == "no")
                    {
                        law.votes.Add(false);
                    }
                }   
                draftLaws.Add(law);
            }
            bool l = false;
            foreach(var x in draftLaws)
            {
                x.parliament = parliament;
            }
            parliament.laws = draftLaws;
            var validd = parliament.ValidLaws();
 /*           foreach(var e in  validd)
            {
               // Console.WriteLine(e.ToString());
                Console.WriteLine(e);
            }*/
            foreach(var e in draftLaws)
            {
                Console.WriteLine(e.IsValid());
                
            }
            if (validd.Count == 0)
            {
                Console.WriteLine("none");
            }
        }
    }
}