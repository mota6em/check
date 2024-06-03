using program;
using TextFile;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //A Bolygó osztály metódusainak viselkedésének tesztelése
        [TestMethod]
        public void BolygóTest()
        {
           
            List<Növény> növények = new List<Növény>();
            Növény n1 = new Puffancs("Pufi", 13);
            Növény n2 = new Deltafa("Dlfa", 13);
            növények.Add(n1);
            növények.Add(n2);
            Sugárzás sug = new AlfaSugárzás(8, 2);
            Bolygó bolygó = new Bolygó(2, növények, sug);

            Assert.AreEqual(bolygó.maiSugárzás().getAlfaIgény(), 8);
            Assert.AreEqual(bolygó.maiSugárzás().getDeltaIgény(), 2);

            //hatás() metódus tesztelése
            bolygó.hatás();

            Assert.AreEqual(növények[0].getTápmennyi(), 13);
            Assert.AreEqual(növények[1].getTápmennyi(), 7);
            
            //maiSugárzás() metódus tesztelése
            Assert.AreEqual(8, bolygó.maiSugárzás().getAlfaIgény());
            Assert.AreEqual(4, bolygó.maiSugárzás().getDeltaIgény());

            //legéletrevalóbb() metódus tesztelése
            Assert.AreEqual("Dlfa", bolygó.legéletrevalóbb());
        }

        //Minden növényfajta különböző sugárzási viselkedésének tesztelése 
        [TestMethod]
        public void NövényTest()
        { 

            //Puffancs esetén
            Növény növény = new Puffancs("Pufi", 13);
            Sugárzás sug = new AlfaSugárzás(8, 2);
            növény.Kölcsönhatás(sug);
            Assert.AreEqual(15, növény.getTápmennyi());
            sug = new DeltaSugárzás(2, 8);
            növény.Kölcsönhatás(sug);
            Assert.AreEqual(13, növény.getTápmennyi());
            sug = new NincsSugárzás(0, 0);
            növény.Kölcsönhatás(sug);
            Assert.AreEqual(12, növény.getTápmennyi());

            //Deltafa esetén
            növény = new Deltafa("Deli", 13);
            sug = new AlfaSugárzás(8, 2);
            növény.Kölcsönhatás(sug);
            Assert.AreEqual(10, növény.getTápmennyi());
            sug = new DeltaSugárzás(2, 8);
            növény.Kölcsönhatás(sug);
            Assert.AreEqual(14, növény.getTápmennyi());
            sug = new NincsSugárzás(0, 0);
            növény.Kölcsönhatás(sug);
            Assert.AreEqual(13, növény.getTápmennyi());

            //Parabokor esetén
            növény = new Parabokor("Pari", 13);
            sug = new AlfaSugárzás(8, 2);
            növény.Kölcsönhatás(sug);
            Assert.AreEqual(14, növény.getTápmennyi());
            sug = new DeltaSugárzás(2, 8);
            növény.Kölcsönhatás(sug);
            Assert.AreEqual(15, növény.getTápmennyi());
            sug = new NincsSugárzás(0, 0);
            növény.Kölcsönhatás(sug);
            Assert.AreEqual(14, növény.getTápmennyi());


        }

        //Az egyes sugárzástípusok viselkedésének tesztelése különböző növényfajtákkal
        [TestMethod]
        public void SugárzásTest()
        {
            Sugárzás sug = new NincsSugárzás(0, 0);
            Növény pufi = new Puffancs("Pufi", 13);
            Növény pari = new Parabokor("Pari", 13);
            Növény deli = new Deltafa("Deli", 13);

            //NincsSugárzás viselkedésének tesztelése különböző növényfajtákkal

            pufi.Kölcsönhatás(sug);
            Assert.AreEqual(10, sug.getAlfaIgény());
            Assert.AreEqual(0, sug.getDeltaIgény());
            pari.Kölcsönhatás(sug);
            Assert.AreEqual(10, sug.getAlfaIgény());
            Assert.AreEqual(0, sug.getDeltaIgény());
            deli.Kölcsönhatás(sug);
            Assert.AreEqual(10, sug.getAlfaIgény());
            Assert.AreEqual(0, sug.getDeltaIgény());

            //AlfaSugárzás viselkedésének tesztelése különböző növényfajtákkal
            sug = new AlfaSugárzás(0, 0);

             pufi = new Puffancs("Pufi", 100);
             pari = new Parabokor("Pari", 100);
             deli = new Deltafa("Deli", 100);
            pufi.Kölcsönhatás(sug);
            Assert.AreEqual(10, sug.getAlfaIgény());
            Assert.AreEqual(0, sug.getDeltaIgény());
            pari.Kölcsönhatás(sug);
            Assert.AreEqual(10, sug.getAlfaIgény());
            Assert.AreEqual(0, sug.getDeltaIgény());
            deli.Kölcsönhatás(sug);
            Assert.AreEqual(10, sug.getAlfaIgény());
            Assert.AreEqual(0, sug.getDeltaIgény());


            //DeltaSugárzás viselkedésének tesztelése különböző növényfajtákkal
            sug = new DeltaSugárzás(0, 0);

            pufi = new Puffancs("Pufi", 100);
            pari = new Parabokor("Pari", 100);
            deli = new Deltafa("Deli", 100);
            pufi.Kölcsönhatás(sug);
            Assert.AreEqual(10, sug.getAlfaIgény());
            Assert.AreEqual(0, sug.getDeltaIgény());
            pari.Kölcsönhatás(sug);
            Assert.AreEqual(10, sug.getAlfaIgény());
            Assert.AreEqual(0, sug.getDeltaIgény());
            deli.Kölcsönhatás(sug);
            Assert.AreEqual(10, sug.getAlfaIgény());
            Assert.AreEqual(0, sug.getDeltaIgény());

        }

        [TestMethod]
        public void FájlInputTest()
        {
           TextFileReader reader = new TextFileReader(@"..\..\..\2dayz.txt");
           int days;
           bool l= reader.ReadInt(out days);
            Assert.AreEqual(2, days);
           List<Növény> növények = new List<Növény>();
           Program.ReadInput(reader, out Növény n1);
            Assert.AreEqual("One", n1.getNév());
            Assert.AreEqual(11,n1.getTápmennyi());
            Program.ReadInput(reader, out Növény n2);
            Assert.AreEqual("Two", n2.getNév());
            Assert.AreEqual(22, n2.getTápmennyi());
        }

        [TestMethod]
        public void SimpleProgramLefordulása()
        {
            TextFileReader reader = new TextFileReader(@"..\..\..\simpleTest.txt");
            string outPut = @"..\..\..\outOfSimpleTest.txt";
            string content = File.ReadAllText(outPut);
            int days;
            bool l = reader.ReadInt(out days);
            List<Növény> növények = new List<Növény>();
            string name, type;
            int nutrient;
            while (Program.ReadInput(reader, out Növény növény))
            {
                // (Feltehetjük hgoy a fájl formátuma helyes) "a feladat alapján".
                növények.Add(növény);
            }
            Sugárzás sug = new NincsSugárzás(0, 0);
            Bolygó bolygó = new Bolygó(days, növények, sug);
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter); // Redirect Console.WriteLine() to StringWriter
            bolygó.hatás();

            string output = stringWriter.ToString().Trim(); // Trim to remove leading/trailing whitespace

            Assert.AreEqual(content, output);

        }
    }
}