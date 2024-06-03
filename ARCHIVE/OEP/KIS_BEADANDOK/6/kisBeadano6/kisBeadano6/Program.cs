using System;
using TextFile;
using System.Collections.Generic;
using System.IO;

namespace KB6
{
    public class program
    {
        public class Áru
        {
            public string cikkszam;
            public int ar;
        }
        public class számla
        {
            public string name;
            //public Áru[] lista;
            public List<Áru> lista;
            public számla(string name, List<Áru> lista)
            {
                this.name = name;
                this.lista = lista;
            }
        }

        public static void Main(string[] args)
        {
            int bevet = 0;
            TextFileReader reader = new TextFileReader(args[0]);
            while (ReadData(reader, out számla sz))
            {
                bevet += ossz(sz.lista);
            }
            Console.WriteLine(bevet);
        }
        public static int ossz(List<Áru> lista)
        {
            int sum = 0;
            foreach (Áru e in lista)
            {
                sum += e.ar;
            }
            return sum;
        }
        public static bool ReadData(TextFileReader reader, out számla sz)
        {
            string line;
            bool isIn = reader.ReadLine(out line);
            List<Áru> itemLists = new List<Áru>();
            if (isIn)
            {
                string[] values = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (values.Length >= 1)
                {
                    string shopName = values[0];

                    for (int i = 1; i < values.Length; i += 2)
                    {
                        if (i + 1 < values.Length)
                        {
                            string tipNumber = values[i];
                            int tipValue;
                            if (int.TryParse(values[i + 1], out tipValue))
                            {
                                Áru item = new Áru();
                                item.ar = tipValue;
                                item.cikkszam = tipNumber;
                                itemLists.Add(item);
                            }
                            else
                            {
                                throw new FormatException("Invalid format for the price");
                            }
                        }
                        else
                        {
                            throw new FormatException("Invalid number of elements in line");
                        }
                    }

                    sz = new számla(shopName, itemLists);
                    return true;
                }
                else
                {
                    throw new FormatException("Empty line or invalid format");
                }
            }
            else
            {
                sz = null;
                return false;
            }
        }
    }
}