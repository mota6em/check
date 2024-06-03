using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1F_Adag
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Deklarálás
            Adagolo gepezet;

            //Inicializáció
            gepezet = new Adagolo(100, 15);
            //Egy sorban ez úgy nézne ki, hogy: Adagolo gepezet = new Adagolo(100,15);
            gepezet.Feltolt();

            //Nyomjuk meg egyszer az adagolót
            gepezet.Nyom();
            //Lekérjük az aktuális mennyiséget (ez a jelenlegi értékekkel 85(=100-15))
            Console.WriteLine(gepezet.GetAkt());

            //Nyomjuk meg mondjuk elég sokszor, hogy kiürüljön
            for (int i = 0; i < 10; i++)//Megjegyzés ha valaki nem ismerné: létrehozunk egy i változót, és 0-tól 9-ig minden értékre végrehajtjuk a { } közti kódot
            {
                gepezet.Nyom();
            }
            Console.WriteLine(gepezet.GetAkt());//ez most nullát ad vissza

            //Feltöltés
            gepezet.Feltolt();
            Console.WriteLine(gepezet.GetAkt());//most már 100-at ad ki

            Console.WriteLine(gepezet.Nev);
            Console.WriteLine(gepezet.szin);
            //Kipróbálhatod, nem létezik olyan, hogy gepezet.termekSzam, mivel a konstans osztályszintű konstans lesz
            Console.WriteLine(Adagolo.termekSzam);
        }
    }
}
