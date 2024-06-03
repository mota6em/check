namespace _3F_Vektor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Vector v1 = new Vector(5,5);
            Vector v2 = new Vector(7,7);

            Vector vPlus = v1 + v2;
            Console.WriteLine($"vPlus = ({vPlus.X},{vPlus.Y})");

            Console.WriteLine(v1*v2);
        }
    }
}