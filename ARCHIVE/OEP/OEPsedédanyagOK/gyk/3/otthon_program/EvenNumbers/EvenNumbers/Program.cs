using TextFile;

namespace EvenNumbers
{
    public class Program { 
        public static void Main(string[] args)
        {
            string filename = Console.ReadLine();
            TextFileReader reader = new TextFileReader(filename);
            bool l = true;
            int max = 0;
            while(reader.ReadInt(out int number))
            {
                if(number > max)
                {
                    max = number;
                }
                if (l)
                {
                    l = (number %2 == 0);
                }
                Console.WriteLine($"A legnagyobb szam: {max}");
                Console.WriteLine("Vege");
            }
        }
    }

}