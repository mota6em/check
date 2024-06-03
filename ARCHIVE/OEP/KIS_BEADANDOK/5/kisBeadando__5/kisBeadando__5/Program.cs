using System;
using TextFile;
using System.IO;

namespace HF5
{
    public class program
    {
        public readonly double e = 0.0;
     
        public static void Main(string[] args)
        { 
            string inputFile = args[0];
            try
            {
                double s = 0.0;
                int db = 0;
                TextFileReader reader = new TextFileReader(inputFile);
                using StreamWriter out1 = new StreamWriter("out1.txt");

                double e;
                ReadE(reader, out e);

                while (e >= 0)
                {
                    s += e;
                    db++;
                    if (!ReadForValue(reader, out e))
                        break;
                }

                bool i = true;
                double kicsi = e;
                while (ReadForValue(reader, out e))
                {
                    i = i && e < 0;
                    if (e < kicsi)
                    {
                        kicsi = e;
                    }
                }

                double a = db != 0 ? s / db : 0;

                Console.WriteLine(a);
                Console.WriteLine(i);
                Console.WriteLine(kicsi);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file does not exist, or it is not in the correct place!");
            }
            
        }

        public static bool ReadForValue(TextFileReader reader, out double e)
        {
            bool isItOver = reader.ReadDouble(out e);
            return isItOver;
        }

        public static void ReadE(TextFileReader reader, out double e)
        {
            reader.ReadDouble(out e);
        }
    }
}