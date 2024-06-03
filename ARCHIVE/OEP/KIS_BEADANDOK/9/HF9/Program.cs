using HF9;

namespace hm
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            Starship starship = new Landingship("Adel", 23, 34, 45);
            if(starship is Wallbreaker)
            {
                Console.WriteLine("well done");
            }
        }
    }
}