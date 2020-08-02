using NUnit.Framework;

namespace Presents.Tests
{
    using System;

    [TestFixture]
    public class PresentsTests
    {

        
        [Test]
        public void TestIfPresentConstrictorWorksCorrectly()
        {
            string exoectedname = "Stick";
            double expectedMagic = 100;

            Present present = new Present(exoectedname, expectedMagic);

            Assert.AreEqual(exoectedname, present.Name);
            Assert.AreEqual(expectedMagic, present.Magic);
        }

        [Test]
        public void TestIfBagCOnstructorWorksCorreclt()
        {
            Bag bag = new Bag();
            
            Assert.IsNotNull(bag.GetPresents());
        }

        [Test]
        public void CreateShouldThrowExoectionWithNullRPesent()
        {
            Bag bag = new Bag();
            Present present = null;

            Assert.Throws<ArgumentNullException>(() => { bag.Create(present); });
        }

        [Test]
        public void CreateSamePresentException()
        {
            Bag bag = new Bag();
            Present present = new Present("Stick", 100);

            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => { bag.Create(present); });
        }
    }
}
