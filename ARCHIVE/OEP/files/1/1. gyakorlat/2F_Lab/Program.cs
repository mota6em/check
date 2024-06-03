namespace _2F_Spiral
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hány oldalas legyen a füzetünk?");
            int oldalszam = int.Parse(Console.ReadLine()!);//itt a felkiáltójel nem szükséges, az egyetlen funkciója jelenleg, hogy elrejti a warning-ot, amit a VS dob, hogy a ReadLine() lehet null is

            Spiralfuzet fuzet = new Spiralfuzet(oldalszam, Típus.sima);

            //Amennyiben egy változó értékét szeretnénk kiíratni egy string-el együtt, annak több módja is van:
            //1.: $ kerül az "" elejére, és ilyenkor az idézőjelek között ha teszünk egy {}-t és beleírjuk a változó nevét
            //2.: "" + <változónév> + "" a WriteLine argumentumaként
            //3.: "{0} {1} {2}", nulladikValtozo, elsoValtozo, stb..
            //Mindhárom a változó átalakításához stringgé automatikusan meghívja a változó ToString metódusát, erről a második gyakorlaton többet
            Console.WriteLine($"Hány üres oldal van jelenleg a füzetünkben? {fuzet.ÜresDB()}");//ilyenkor ha jól csináltuk ez egyenlő az oldalaink számával

            Console.WriteLine("Hanyadik oldalt írjuk tele?");
            bool sikeres = false;
            while (!sikeres)
            {
                oldalszam = int.Parse(Console.ReadLine()!);
                try
                {
                    fuzet.Teleír(oldalszam, "asdasdasdasdasd");
                    sikeres = true;
                } catch (IndexOutOfRangeException)//itt specifikálod hogy milyen exceptiont szeretnél elkapni
                {
                    Console.WriteLine("Ez egy érvénytelen oldalszám volt");
                } catch (Spiralfuzet.PageIsFullException)//amennyiben szeretnél dolgozni egy elkapott exception-nel, úgy írj utána egy változónevet amivel hivatkozol rá, pl.: "IndexOutOfRangeException ex" esetén az "ex" alapján tudsz rá hivatkozni
                {
                    Console.WriteLine("Ez az oldal már tele van írva");
                } catch (Exception)//így az összes exceptiont el tudod kapni
                {
                    Console.WriteLine("Nem tudom mit csináltál de kérlek ne csináld köszi");
                } finally//a finally ág minden esetben lefut
                {
                    Console.WriteLine("Lefutott a try-catch");
                }
            }
        }
    }
}
