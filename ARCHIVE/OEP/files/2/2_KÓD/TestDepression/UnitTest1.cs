//Author:   Gregorics Tibor
//Date:     2021.10.24.
//Title:    Test cases of height of the highest depression

using progam;
using TextFile;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MaiSug�rz�sNincsTest()
        {
            // Arrange
            var sug�rz�s = new NincsSug�rz�s(8, 8);
            var bolygo = new Bolyg�(10, new List<N�v�ny>(), sug�rz�s);

            // Act
            var result = bolygo.maiSug�rz�s();

            // Assert
            Assert.Equals("NincsSug�rz�s", result);
            Assert.AreEqual(8, result.getAlfaIg�ny());
            Assert.AreEqual(8, result.getDeltaIg�ny());
        }

    }
}