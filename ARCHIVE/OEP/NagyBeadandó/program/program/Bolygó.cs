using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    public class Bolygó
    {
        private int napok;
        private List<Növény> növények;
        private Sugárzás sugárzás;
        public Bolygó(int napok, List<Növény> növények, Sugárzás sugárzás)
        {
            this.napok = napok;
            this.növények = növények;
            this.sugárzás = sugárzás;
        }
        public void hatás()
        {
            // A hatás előtti kezdeti inputok

            int i = 1;
            while(i <= napok)
            {
                sugárzás = maiSugárzás();
                NapiCiklus();
                
                Console.WriteLine(sugárzás); //a mai sugárzás kiírása
                for (int r = 0; r < növények.Count; r++)
                {
                    //az összes növényt a rájuk jellemző tulajdonságokkal (HATÁS UTÁN)
                    Console.WriteLine(növények[r].getNév() + ", " + növények[r] + ", " + növények[r].getTápmennyi());
                }
                i++;
            }
           
            //Console.WriteLine($"A teljes hatás után az életben maradt egyed a legerősebb: "+ legéletrevalóbb());
            Console.WriteLine(legéletrevalóbb());
        }

        //A napi kölcsönhatás a növények és a sugárzás között.
        public void  NapiCiklus() 
        { 
            int i = 0;
            while (i < növények.Count) 
            {
                if (növények[i].Él()) 
                {
                    növények[i].Kölcsönhatás(sugárzás);
                }
                i++;
            }
        }

        // A bolygón uraékodó sugárzás meghatározása
        public Sugárzás maiSugárzás()
        {
            int a = sugárzás.getAlfaIgény();
            int d = sugárzás.getDeltaIgény();
            if (a - d >= 3)
            {
                return new AlfaSugárzás(a, d);
            }
            else if (d - a >= 3)
            {
                return new DeltaSugárzás(a, d);
            }
            else return new NincsSugárzás(a, d);
        }

        // Az életben maradt egyed legerősebb növény meghatározása az osszes hatás után.
        public string legéletrevalóbb()
        {
            int ind = -1;
            int max = -5;
            int currentInd = 0;
            foreach(Növény e in növények)
            {
                if(e.Él())
                {
                    if(max < e.getTápmennyi())
                    {
                        max = e.getTápmennyi();
                        ind = currentInd;
                    }
                }
                currentInd++;
            }
            if (ind == -1)
            {
                return "Minden növény elpusztult";
            }
            else return növények[ind].getNév();
        }
    }
}
