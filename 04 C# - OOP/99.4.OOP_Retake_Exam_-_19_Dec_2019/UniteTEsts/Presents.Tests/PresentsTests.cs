using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;

namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void AddNullPresent()
        {
            Bag bag = new Bag();
            Present present = null;

            Assert.Throws<ArgumentNullException>(() => { bag.Create(present); });
        }

        [Test]
        public void AddSamePresent()
        {
            Bag bag = new Bag();
            Present present = new Present("Georgi",15);

            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => { bag.Create(present); });
        }

        [Test]
        public void RemoveSuccesfull()
        {
            Bag bag = new Bag();
            Present present = new Present("Georgi", 15);

            bag.Create(present);

            bool isT  = bag.Remove(present);

            Assert.IsTrue(isT);
        }

        [Test]
        public void GetWIthLeastMAgincWorks()
        {
            Bag bag = new Bag();
            Present present = new Present("Georgi", 15);
            Present presen2t = new Present("Georgi2", 150);
            Present present3 = new Present("Georgi3", 15000);

            bag.Create(present);
            bag.Create(presen2t);
            bag.Create(present3);

            var actual = bag.GetPresentWithLeastMagic();
            Assert.AreEqual(present,actual);
        }

        [Test]
        public void GetPresentCOrrect()
        {
            Bag bag = new Bag();
            ICollection<Present> presents = new List<Present>();

            Present present = new Present("Georgi", 15);
            Present presen2t = new Present("Georgi2", 150);
            Present present3 = new Present("Georgi3", 15000);

            bag.Create(present);
            bag.Create(presen2t);
            bag.Create(present3);

            presents.Add(present);
            presents.Add(presen2t);
            presents.Add(present3);

            IReadOnlyCollection<Present> actual = bag.GetPresents();


            CollectionAssert.AreEqual(presents, actual);
        }

        [Test]
        public void GetPResentsInvorrect()
        {
            Bag bag = new Bag();

            Present present = new Present("Georgi", 15);

            bag.Create(present);

            var actual = bag.GetPresent("Georgi");

            Assert.AreEqual(present, actual);
        }
    }
}
