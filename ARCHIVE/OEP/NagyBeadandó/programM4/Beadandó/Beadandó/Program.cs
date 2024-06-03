using Beadandó;
using TextFile;
namespace Beadando
{
    public class Bolygó
    {
        private Sugárzás sugárzás = new Sugárzás();
        private Növény[] növények;
        private int napok;
        public void Hatás() 
        {
            int j = 1;
            while(j <= napok)
            {   
                int A = sugárzás.alfa_igény;
                int D = sugárzás.delta_igény;
                Kölcsönhatás();
                lépésekNyomtatása(j, sugárzás.sugMeghatározása(), A, D);
                j++;
            }
            string legerősebb = MXtápanyagKERESÁS();
            Console.WriteLine(napok + " nap után a " + legerősebb );
        }
        public void Kölcsönhatás() 
        {
            string sug = sugárzás.sugMeghatározása();
            int i = 0;
            while (i < növények.Length) 
            {
                if (növények[i].Él())
                {
                    növények[i].TápanyagMódosító(sug);
                    if (növények[i].fajta == "p")
                    {
                        sugárzás.adAlfaSug(10);
                    }
                    else if (növények[i].fajta == "d")
                    {
                        if (növények[i].tápanyag < 5)
                        {
                            sugárzás.adDeltaSug(4);
                        }
                        else if (növények[i].tápanyag >= 5 && növények[i].tápanyag <= 10)
                        {
                            sugárzás.adDeltaSug(1);
                        }
                        else { }
                    }
                }
                i++;
            }
            
        }
        public string MXtápanyagKERESÁS()
        {
            int max = 0;
            int ind = 0;
            for(int i  = 0;  i < növények.Length; i++)
            {
                if (növények[i].tápanyag > max && növények[i].Él())
                {
                    max = növények[i].tápanyag;
                    ind =i;
                }
            }
            if(ind == 0)
            {
                return "minden növény elpusztult";
            }
            else
            {
                return növények[ind].név + " növény maradt egyed a legerősebb!";
            }
        }
        public void lépésekNyomtatása(int n, string sug , int a, int d)
        {
            Console.WriteLine("Nap: " + n);
            Console.WriteLine("Aktuális Sugárzás: " + sug +", A "+ a +", D "+ d);
            Console.WriteLine("Növények állapotai: ");
            for(int i = 0; i < növények.Length; i++)
            {
                Console.WriteLine(növények[i].név + " " + növények[i].fajta + " " + növények[i].tápanyag);
            }
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            Bolygó obj = new Bolygó();
        //    obj.napok = int.Parse(Console.ReadLine());
        //    TextFileReader reader = new TextFileReader("input.txt");
            obj.napok = 10;
            obj.növények = new Növény[4];
            obj.növények[0] = new Növény("Falánk" , "p" , 7);
            obj.növények[1] = new Növény("Sudár", "d", 5);
            obj.növények[2] = new Növény("Köpöcs", "b", 4);
            obj.növények[3] = new Növény("Nyúlánk" , "d" , 3);



            obj.Hatás();
        }

    }
}
