using TextFile;

namespace Baggings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                TextFileReader reader = new TextFileReader("input.txt");
                Bag bag = new Bag();

                while (reader.ReadString(out string word))
                {
                    bag.Insert(word);
                }

                Console.WriteLine($"The most frequent element: {bag.Max()}");

            } catch (FileNotFoundException)
            {
                Console.WriteLine("The file does not exist, or it is not in the correct place!");
            }
            catch (Bag.EmptyBagException)
            {
                Console.WriteLine("The bag is empty!");
            }
        }
    }
}