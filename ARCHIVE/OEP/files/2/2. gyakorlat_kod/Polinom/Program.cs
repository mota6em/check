using TextFile;

namespace Polinom
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //TextFileReader osztály használata
            //Amikor csinálsz egy TFR osztályt, meg kell adni a konstruktornak a teljes fájlnevet:
            //Fájl helye: bin/Debug/net8.0 (avagy 7, amelyikkel dolgozol)
            TextFileReader reader = new TextFileReader("input.txt");

            //A readLine hasonlóan működik, mint Console-on
            string[] line = reader.ReadLine().Split(' ');
            foreach (string word in line)
            {
                Console.WriteLine("Words of simple ReadLine: " + word);
            }
            if (reader.ReadLine(out string s))
            {
                Console.WriteLine("Words of ReadLine with out parameter: " + s);
            }

            //ReadChar
            Console.WriteLine("Simple ReadChar: " + reader.ReadChar());
            if(reader.ReadChar(out char c))
            {
                Console.WriteLine("ReadChar with out parameter: " + c);
            }

            //ReadString
            Console.WriteLine("Simple ReadString: " + reader.ReadString());
            if(reader.ReadString(out string st))
            {
                Console.WriteLine("ReadString with out parameter: " + st);
            }

            //ReadInt
            Console.WriteLine("Simple ReadInt: " + reader.ReadInt());
            if (reader.ReadInt(out int i))
            {
                Console.WriteLine("ReadInt with out parameter: " + i);
            }

            //ReadDouble
            Console.WriteLine("Simple ReadDouble: " + reader.ReadDouble());
            if (reader.ReadDouble(out double d))
            {
                Console.WriteLine("ReadDouble with out parameter: " + d);
            }
        }
    }
}