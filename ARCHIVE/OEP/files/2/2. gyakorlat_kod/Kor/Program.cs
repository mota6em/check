namespace Kor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Pont p1 = new Pont(10, 10);
            Pont p2 = new Pont(15, 15);
            Pont p3 = new Pont(0, 10);
            Pont p4 = new Pont(-2, -2);

            Kor k1 = new Kor(p1, 10);

            Console.WriteLine($"P1 pont ({p1.X}, {p1.Y}) P2 pontól ({p2.X},{p2.Y}) vett távolsága: {p1.Távolság(p2)}");
            Console.WriteLine($"P1 pont ({p1.X}, {p1.Y}) P3 pontól ({p3.X},{p3.Y}) vett távolsága: {p1.Távolság(p3)}");

            Console.WriteLine($"P1 pont ({p1.X}, {p1.Y}) és P2 pont ({p2.X},{p2.Y}) távolsága: {KétPontTávolsága(p1, p2)}");
            Console.WriteLine($"P1 pont ({p3.X}, {p3.Y}) és P2 pont ({p4.X},{p4.Y}) távolsága: {KétPontTávolsága(p3, p4)}");

            Console.WriteLine("\nRajta van-e az adott pont K1 kör körlapján?");
            Console.WriteLine($"P1 pont: {k1.Tartalmaz(p1)}");
            Console.WriteLine($"P2 pont: {k1.Tartalmaz(p2)}");
            Console.WriteLine($"P3 pont: " + (k1.Tartalmaz(p3) ? "Igaz" : "Hamis"));
            Console.WriteLine($"P4 pont: {k1.Tartalmaz(p4)}");
        }

        public static double KétPontTávolsága(Pont p1, Pont p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}