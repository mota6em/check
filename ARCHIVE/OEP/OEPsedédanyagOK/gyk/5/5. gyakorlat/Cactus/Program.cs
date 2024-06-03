using TextFile;

namespace Cactus
{
    public class Cactus
    {
        public readonly string name, color, home;
        public readonly int size;

        public Cactus(string name, string color, string home, int size)
        {
            this.name = name;
            this.color = color;
            this.home = home;
            this.size = size;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting operation...");
            TextFileReader reader = new TextFileReader("input.txt");
            using StreamWriter out1 = new StreamWriter("out1.txt");//using...?
            using StreamWriter out2 = new StreamWriter("out2.txt");//using...?
            while (ReadCactus(reader, out Cactus kaktusz))
            {
                if (kaktusz.home == "Mexico")
                {
                    out1.WriteLine(kaktusz.name);
                    Console.WriteLine(kaktusz.name);
                }
                if (kaktusz.color == "red")
                {
                    out2.WriteLine(kaktusz.name);
                    Console.WriteLine(kaktusz.name);
                }
            }
            Console.WriteLine("Operation ended...");
        }

        public static bool ReadCactus(TextFileReader reader, out Cactus kaktusz)
        {
            bool isItOver = reader.ReadString(out string name);
            reader.ReadString(out string home);
            reader.ReadString(out string color);
            reader.ReadInt(out int size);
            kaktusz = new Cactus(name, color, home, size);

            return isItOver;
        }
    }
}