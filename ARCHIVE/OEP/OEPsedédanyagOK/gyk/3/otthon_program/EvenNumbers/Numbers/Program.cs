using TextFile;

namespace Numbers
{
    public class Program
    {
        public static void Main(string[] args) 
        
        {
            TextFileReader reader = new TextFileReader("input.txt");
            int evens = 0;
            bool negative  = false;
            while (reader.ReadInt(out int numbers) && !negative)
            {
                if(numbers < 0)
                {
                    negative = true; ;
                }
                else
                {
                    if(numbers % 2 == 0)
                    {
                        evens++;
                    }
                }
            }
            Console.WriteLine($"Event of evens: {evens}");

        }
    }
}