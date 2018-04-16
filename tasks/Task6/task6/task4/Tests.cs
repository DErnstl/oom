using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using task6;

namespace Test
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void SimpleTest()
        {
            Assert.IsTrue(1 == 1);
        }

        [Test]
        public void CheckInitialisationOfAPlayer()
        {
            var init = new TransferMarket("ASDF", "FDSA", 55, "FC Test", 123456);
            Assert.IsTrue(init.Name.PFirstName == "ASDF");
            Assert.IsTrue(init.Name.PSecondName == "FDSA");
            Assert.IsTrue(init.Age == 55);
            Assert.IsTrue(init.Club == "FC Test");
            Assert.IsTrue(init.MarketValue == 123456);
        }

        [Test]
        public void CannotCreateAPlayerWithoutAFirstname1()
        {
            Assert.Catch(() =>
            {
                var init = new TransferMarket("", "FDSA", 55, "FC Test", 123456);
            });
        }

        [Test]
        public void CannotCreateAPlayerWithoutAFirstname2()
        {
            Assert.Catch(() =>
            {
                var init = new TransferMarket(null, "FDSA", 55, "FC Test", 123456);
            });
        }

        [Test]
        public void CannotCreateAPlayerWithoutASecondname1()
        {
            Assert.Catch(() =>
            {
                var init = new TransferMarket("ASDF", "", 55, "FC Test", 123456);
            });
        }

        [Test]
        public void CannotCreateAPlayerWithoutASecondname2()
        {
            Assert.Catch(() =>
            {
                var init = new TransferMarket("ASDF", null, 55, "FC Test", 123456);
            });
        }

        [Test]
        public void CannotCreateAPlayerWithANegativeAge1()
        {
            Assert.Catch(() =>
            {
                var init = new TransferMarket("ASDF", "FDSA", -1, "FC Test", 123456);
            });
        }

        [Test]
        public void CannotCreateAPlayerWithAAgeOver200()
        {
            Assert.Catch(() =>
            {
                var init = new TransferMarket("ASDF", "FDSA", 201, "FC Test", 123456);
            });
        }

        [Test]
        public void CannotCreateAPlayerWithANegativeMarketvalue()
        {
            Assert.Catch(() =>
            {
                var init = new TransferMarket("ASDF", "FDSA", 55, "FC Test", -1);
            });
        }

    }
}
