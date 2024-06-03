using TextFile;

namespace program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Növény> növények = new List<Növény> { };
            int napok;
            Sugárzás sugárzás = new NincsSugárzás(0, 0);

            try
            {
                TextFileReader reader = new TextFileReader(@"..\..\..\input.txt"); ;
                try
                {
                    bool success = reader.ReadInt(out napok);

                    if (!success)
                    {
                        Console.WriteLine("Nem sikerült leolvasni a napok számát.");
                        return;
                    }
                    if (napok < 0)
                    {
                        throw new Exception("A napok száma nem lehet negatív szám!");
                    }
                    string name, type;
                    int nutrient;
                    while (ReadInput(reader, out Növény növény))
                    {
                        // (Feltehetjük hgoy a fájl formátuma helyes) "a feladat alapján".
                        növények.Add(növény);
                    }
                    Bolygó bolygó = new Bolygó(napok, növények, sugárzás);
                    bolygó.hatás();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);  
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba van a fájl formátumában\n\n...");
            }            
         }
        public static bool ReadInput(TextFileReader reader, out Növény növény)
        {
            bool l = reader.ReadString(out string name);
            reader.ReadString(out string type);
            reader.ReadInt(out int nutrient);
            if (type == "p")
            {
                növény = new Puffancs(name, nutrient);
            }
            else if (type == "d")
            {
                növény = new Deltafa(name, nutrient);
            }
            else 
            {
                növény = new Parabokor(name, nutrient);
            }
           
            return l;
        } 
    }
}





























/*Console.WriteLine("Kérem a teszt fájl számtát: \n1 - text1.txt\n2 - text2.txt\n3 - text3.txt\n4 - text4.txt");
                   int choice = int.Parse(Console.ReadLine());
                   switch (choice)
                   {
                       case 1:
                           reader = new TextFileReader("test1.txt");
                           break;
                       case 2:
                           reader = new TextFileReader("test2.txt");
                           break;
                       case 3:
                           reader = new TextFileReader("test.txt");
                           break;
                       case 4:
                           reader = new TextFileReader("test4.txt");
                       break;
                       default:
                           Console.WriteLine("Helyetlen bemenet!");
                           throw new Exception();
                       break;
                   }
*/