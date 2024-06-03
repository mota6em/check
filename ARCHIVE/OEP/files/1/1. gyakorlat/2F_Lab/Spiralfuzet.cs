using System.Runtime.ExceptionServices;

namespace _2F_Spiral
{
    #region Segédtípusok
    public enum Típus { sima, négyzetrács, vonal }

    public class Lap
    {
        public bool státusz;
        public string tart;

        //lehetséges több konstruktor/metódus is ugyanazzal a névvel, viszont ez esetben a paramétereknek különbözniük kell, pl valamelyik kap egy stringet, a másik nem kap semmit
        //amennyiben nem különböznek, arra már hibát fogunk kapni
        //különbözésnek számít a más sorrend is, nem tudom ezt mondjuk miért akarná valaki mondjuk... *the more you know*
        //Lásd pl itt:
        public Lap(bool st, string tart)
        {
            státusz = st;
            this.tart = tart;
        }
        
        public Lap(string tart, bool st) {
            státusz = st;
            this.tart = tart;
        }
        public Lap()
        {
            státusz = false;
            tart = "";
        }
    }
    #endregion

    public class Spiralfuzet
    {
        #region Adattagok
        private Típus típus;
        private List<Lap> lapok;
        private int teli;
        #endregion


        //Származtatás jelzése: ':'
        //Jelen esetben ez azt jelenti, hogy a PageIsFullException egy "gyereke" az Exception (alapértelmezett) osztálynak
        //A { }-en belül pedig ha szeretnénk valami az osztályra specifikus kódot írni, esetleg felülírni az eredeti metódusok valamelyikét, megtehetjük, erről többet majd később többet
        public class PageIsFullException : Exception { }


        #region Konstruktor
        public Spiralfuzet(int n, Típus tip)
        {
            típus = tip;
            teli = 0;
            lapok = new List<Lap>();

            //Amennyiben az if/for/while stb ciklusokban/elágazásokban csak egyetlen művelet van, úgy nem kötelező kitenni a { }
            //Nem kötelező így használni, csak aki szeretné, ez is egy lehetőség
            for (int i = 0; i < n; i++)
                lapok.Add(new Lap());
        }
        #endregion

        #region Metódusok
        public int ÜresDB()
        {
            //méret lekérdezése:
            //tömböknél: <tömbnév>.length
            //listáknál: <listanév>.Count
            return lapok.Count - teli;
        }
        public void Kitép(int ind)
        {
            /*
             * Aki esetleg nem látott ilyet:
             * megnöveljük egyel az adott változót: ind++; ++ind;
             * csökkentjük egyel az adott számot: ind--; --ind;
             * adjunk hozzá/vonjunk ki/szorozzuk meg/osszuk el a változót a megadott értékkel:
             *  ind+=<érték>
             *  ind-=<érték>
             *  ind*=<érték>
             *  ind/=<érték>
             *      pl: ind = 5; ind*=3; ilyenkor az eredeti (5) értéket megszorozzuk 3-al, és az ind felveszi az új (15) értéket
             */
            ind--;

            if (ind < 0 || ind >= lapok.Count)
                throw new IndexOutOfRangeException();

            if (lapok.ElementAt(ind).státusz == true)
                teli -= 1;

            lapok.RemoveAt(ind);
        }
        public void Teleír(int ind, string tart)
        {
            ind--;
            //Így lehet egy Exception-t "dobni", ha volt már olyan, - valószínűleg igen :D
            //      hogy leállt a programod egy hiba miatt, pl nullával osztás, kiindexeltél egy tömbből, akkor annak a hibakódnak a dobása is így néz ki
            //Ennek az "elkapása" egy try-catch-el lehetséges, lásd: Main függvény
            if(ind < 0 || ind > lapok.Count)
                throw new IndexOutOfRangeException();
            else if (lapok.ElementAt(ind).státusz == true)
                throw new PageIsFullException();

            lapok.ElementAt(ind).státusz = true;
        }

        //OUT és REF kulcsszavak
        //Lényegében mindkettő ugyanazt csinálja, értéket ad egy változónak amit a metódus meghívása után tudunk használni
        //Fő különbség:
        //out esetén nem kell inicializálni a metódust meghívó programban a változót, viszont a metódus végezte előtt muszáj értéket kapnia
        //ref esetén már egy létező változó referenciáját adjuk át, így annak már inicializálva kell lennie, és ezt változtatja meg a metódus úgy, hogy az új értékét megtartja az eredeti változó
        //(alapból ha átadsz egy értéket egy metódusnak és megváltoztatod az értékét, akkor a hívó programrészben ez a változás nem fog bekövetkezni)
        public bool Keres(out int ind)
        {
            ind = 0;

            while (ind < lapok.Count && lapok[ind].státusz == true)
                ind++;

            if (ind < lapok.Count)
            {
                ind++;
                return true;
            }

            return false;
        }
        #endregion
    }
}
