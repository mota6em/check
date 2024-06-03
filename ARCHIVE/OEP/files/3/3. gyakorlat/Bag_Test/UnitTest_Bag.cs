using Baggings;

namespace Bag_Test
{
    [TestClass]
    public class UnitTest_Bag
    {
        [TestMethod]
        public void TestofInsert()
        {
            Bag bag = new Bag();
            Assert.AreEqual(bag.ToString(), "[]");

            bag.Insert("barack");
            Assert.AreEqual(bag.ToString(), "[(barack, 1)]");

            bag.Insert("barack");
            bag.Insert("alma");
            Assert.AreEqual(bag.ToString(), "[(alma, 1)(barack, 2)]");
        }

        [TestMethod]
        public void TestofSetEmpty()
        {
            Bag bag = new Bag();

            bag.Insert("barack");
            Assert.AreEqual(bag.ToString(), "[(barack, 1)]");

            bag.SetEmpty();
            Assert.AreEqual(bag.ToString(), "[]");
        }

        [TestMethod]
        public void TestofEmpty()
        {
            Bag bag = new Bag();
            Assert.AreEqual(bag.Empty(), true);

            bag.Insert("barack");
            Assert.AreEqual(bag.Empty(), false);
        }

        [TestMethod]
        public void TestofMultiple()
        {
            Bag bag = new Bag();
            Assert.AreEqual(bag.Multiple("barack"), 0);

            bag.Insert("barack");
            bag.Insert("alma");
            bag.Insert("barack");
            Assert.AreEqual(bag.Multiple("barack"), 2);
        }

        [TestMethod]
        public void TestofMax()
        {
            Bag bag = new Bag();
            Assert.ThrowsException<Bag.EmptyBagException>( () => bag.Max());

            bag.Insert("alma");
            bag.Insert("barack");
            bag.Insert("barack");
            Assert.AreEqual(bag.Max(), "barack");
        }

        [TestMethod]
        public void TestOfRemove()
        {
            Bag bag = new Bag();
            bag.Insert("alma");
            bag.Insert("barack");
            bag.Insert("barack");

            Assert.AreEqual(bag.ToString(), "[(alma, 1)(barack, 2)]");
            Assert.AreEqual(bag.Max(), "barack");

            bag.Remove("barack");
            Assert.AreEqual(bag.ToString(), "[(alma, 1)(barack, 1)]");
            Assert.AreEqual(bag.Max(), "alma");

            bag.Remove("alma");
            Assert.AreEqual(bag.ToString(), "[(barack, 1)]");
            Assert.AreEqual(bag.Max(), "barack");
        }
    }
}