using MAP;

namespace HOME
{
    public class MAP
    {
        public static void Main(string[] args)
        {
            Asszomb asszomb = new Asszomb(5);
            /*try
            {
                Console.WriteLine("Testing SetAt:");
                asszomb.SetAt(1, "Value1");
                asszomb.SetAt(2, "Value2");
                asszomb.SetAt(3, "Value3");
                Console.WriteLine("SetAt successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("SetAt failed: " + e.Message);
            }*/

            // Testing GetAt
            try
            {
                Console.WriteLine("\nTesting GetAt:");
                Console.WriteLine("Value at key 1: " + asszomb.GetAt(1));
                Console.WriteLine("Value at key 2: " + asszomb.GetAt(2));
                Console.WriteLine("Value at key 3: " + asszomb.GetAt(3));
                Console.WriteLine("GetAt successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("GetAt failed: " + e.Message);
            }

            // Testing IsIn
            Console.WriteLine("\nTesting IsIn:");
            Console.WriteLine("Is key 1 in the Asszomb? " + asszomb.IsIn(1));
            Console.WriteLine("Is key 4 in the Asszomb? " + asszomb.IsIn(4));

            // Testing RemoveAt
            try
            {
                Console.WriteLine("\nTesting RemoveAt:");
                asszomb.RemoveAt(1);
                Console.WriteLine("Removed key 1 from Asszomb");
                Console.WriteLine("New count: " + asszomb.Count());
                Console.WriteLine("RemoveAt successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("RemoveAt failed: " + e.Message);
            }

            // Testing IsEmpty
            Console.WriteLine("\nTesting IsEmpty:");
            Console.WriteLine("Is Asszomb empty? " + asszomb.IsEmpty());

            // Testing SetEmpty
            Console.WriteLine("\nTesting SetEmpty:");
            asszomb.SetEmpty();
            Console.WriteLine("Emptied Asszomb");

            // Testing Count
            Console.WriteLine("\nTesting Count:");
            Console.WriteLine("Count of Asszomb: " + asszomb.Count());

            // Printing the contents of Asszomb
            Console.WriteLine("\nAsszomb contents: " + asszomb);

            Console.WriteLine("\nHello");
        }
    }
}