using System.Security.Cryptography.X509Certificates;
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
    public class program 
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting opertaion.. ");
            TextFileReader reader = new TextFileReader("input.txt");
            StreamWriter out1 = new StreamWriter("out1.txt");
            StreamWriter out2 = new StreamWriter("out2.txt");
            while(ReadCactus(reader, out Cactus kakrusz))
            {
                if(kakrusz.home == "Mexico")
                {
                    out1.WriteLine(kakrusz.name);
                    Console.WriteLine(kakrusz.name);
                }
                if(kakrusz.color == "red")
                {
                    out2.WriteLine(kakrusz.name);
                    Console.WriteLine(kakrusz.name);
                }
            }
            Console.WriteLine("Operarion ended...");
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