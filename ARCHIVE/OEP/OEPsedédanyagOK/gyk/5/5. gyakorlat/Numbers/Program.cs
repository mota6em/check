using TextFile;
namespace Numbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TextFileReader reader = new TextFileReader("input.txt");
            int evens = 0;
            bool negative = false;
            while (!negative && reader.ReadInt(out int number))
            {
                if (number < 0)
                {
                    Console.WriteLine($"Number of evens: {evens}");
                    evens = 0;
                    negative = true;
                }
                if (number % 2 == 0)
                {
                    evens++;
                }
            }
            while (reader.ReadInt(out int number))
            {
                if (number % 2 == 0)
                {
                    evens++;
                }
            }
            Console.WriteLine($"Number of evens: {evens}");
        }
    }
}