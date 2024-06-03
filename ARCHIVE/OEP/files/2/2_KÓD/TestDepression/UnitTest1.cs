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
        public void MaiSugárzásNincsTest()
        {
            // Arrange
            var sugárzás = new NincsSugárzás(8, 8);
            var bolygo = new Bolygó(10, new List<Növény>(), sugárzás);

            // Act
            var result = bolygo.maiSugárzás();

            // Assert
            Assert.Equals("NincsSugárzás", result);
            Assert.AreEqual(8, result.getAlfaIgény());
            Assert.AreEqual(8, result.getDeltaIgény());
        }

    }
}