using Microsoft.Win32.SafeHandles;

namespace _1F_Adag
{
    public class Adagolo
    {

        #region Adattagok
        //Az adattagok láthatósága jelen esetben privát, amúgy 3 fontosabb féle lehet: public / protected / private
        // + public:    elérhető az osztályon kívülről
        // # protected: elérhető osztályon belül és alosztályokból
        // - private:   csak ebből az osztályból érhető el
        // (esetleg internal még hasznos néha, internal-nál csak a saját projektjében látható az osztály)
        private int tele;
        private int adag;
        private int akt;
        #endregion

        #region Konstruktor
        //ez felel a az osztály példányosításáért:
        //Adagolo adag = new Adagolo(5,1);
        //Adagolo: az adag változó típusa
        //new Adagolo(5,1): meghívja a konstruktort az 5 és 1 értékekkel
        public Adagolo(int k, int e)
        {
            tele = k;
            adag = e;
            akt = 0;

            //Bónusz
            //Lásd: lejjebb
            Nev = "Unit501";
            szin = "sárga";
        }
        #endregion

        #region Metódusok
        //Használatuk: a.Nyom() valamint a.Feltolt() ahol 'a' egy Adagolo osztály referenciája
        //Kaphatnak pl. static jelzőt is, ezzel a metódus konkrét objektumtól függetlenül lehetne használható (osztályszinten használható/osztályszintű)
        //pl: Nyom() avagy Adagolo.Feltolt(), az osztálynév akkor szükséges elé, ha az osztály kódján kívül hivatkozunk a metódusra
        //Lásd: majd a második gyakorlaton
        public void Nyom()
        {
            //jelen esetben: this.akt ekvivalens akt-al
            //amennyiben pl kapnánk egy paramétert amit szintén akt-nak neveznénk el, akkor szükség lenne a this-re hogy jelezzük, melyik akt-ra gondolunk
            akt = Math.Max(0, akt - adag);
        }

        public void Feltolt()
        {
            akt = tele;
        }
        #endregion

        #region Getter/Setter
        //A Getter metódusokat arra szoktuk használni, hogy az osztályon kívülről lekérjük egy onnan nem látható adattag állapotát
        //Neve általában Get<adattagnév>, nem kötelező követni, de érdemes
        public int GetAkt()
        {
            return akt;
        }
        //Egy Setter metódus nagyban hasonlít a Getter-re (ki gondolta volna), annyi különbséggel, hogy itt visszatérési érték általában nincs, és nem lekérjük hanem értéket adunk egy adattagnak
        //Főként akkor hasznos, ha valami kikötésünk van az adattag értékére (pl nem lehet negatív) és ezt alkalmazva tudjuk ellenőrizni a beállítandó érték helyességét
        public void SetAdag(int adag)
        {
            if (adag > 0 && adag < tele)
            {
                //Ilyen esetben kell használni a this-t, ha nincs ott, jelzi a program nekünk hogy valami nem okés
                this.adag = adag;
            }
        }
        #endregion

        #region Property
        //Ezt úgy kell elképzelni, hogy csinálunk egy Nev adattagot, amit ellátunk egy "gyárilag beépített" getter és setter metódussal
        //Jelen esetben ez a Nev property egy olyan property, hogy 'kívülről' ugyanúgy férsz hozzá mint egy publikus adattaghoz,
        //  annyi különbséggel, hogy csak lekérdezést engedélyez, értékadást nem - lásd: private set, hisz a private láthatóság miatt csak osztályon belülről tudsz neki értéket adni
        public string Nev { get; private set; }
        #endregion

        #region Kis bónusz
        //NEM FONTOS: EZEKET JELENLEGI TUDÁSOM SZERINT NEM FOGJUK IDÉN HASZNÁLNI (de megint csak: *the more you know*)
        //const: ezzel tudunk deklarálni egy konstans adattagot
        //readonly: ezzel tudunk deklarálni egy csak olvasható adattagot
        //DE MI IS A KÜLÖNBSÉG?
        //pl.:
        public const int termekSzam = 501;
        public readonly string szin;
        //A legnyilvánvalóbb különbség:
        // a konstans adattagnak a deklarálásnál azonnal kell értéket adni
        // a readonly adattagnak ugyanúgy csak egyszer lehet értéket adni mint a konstansnak, nem lehet majd utána változtatni, de itt nem kötelező már a deklarálásnál értéket adni
        // ui.: lásd konstruktor

        //A második, kevésbé nyilvánvalóbb különbség: const-tal deklarálva egy érték NEM adattag lesz, az egy osztályhoz kötött konstans lesz, amihez konkrét inicializálás nélkül hozzá tudsz férni
        //Lásd: Program.cs
        #endregion
    }
}
