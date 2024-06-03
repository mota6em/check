namespace Komplex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Komplex c1 = new Komplex(3.5, 4.2);
            Komplex c2 = new Komplex(2.6, 3);
            int result = 0;
            do
            {
                Console.Clear();
                Console.WriteLine($"Első szám: {c1}\nMásodik szám: {c2}");
                Console.WriteLine("Lehetséges műveletek:");
                Console.WriteLine("1. Két szám összeadása");
                Console.WriteLine("2. Két szám kivonása");
                Console.WriteLine("3. Két szám szorása");
                Console.WriteLine("4. Két szám osztása");
                Console.WriteLine("5. Kilépés");
                Console.Write("\nElőző művelet eredménye: ");
                switch (result)
                {
                    case 1:
                        Console.WriteLine(c1 + c2);
                        break;
                    case 2:
                        Console.WriteLine(c1 - c2);
                        break;
                    case 3:
                        Console.WriteLine(c1 * c2);
                        break;
                    case 4:
                        Console.WriteLine(c1 / c2);
                        break;
                    default:
                        Console.WriteLine("---");
                        break;
                }
            } while (int.TryParse(Console.ReadLine(), out result) && result != 5);
        }
    }
}