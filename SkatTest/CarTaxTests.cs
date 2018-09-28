using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skat;

namespace SkatTest
{
    [TestClass]
    public class CarTaxTests
    {
        [TestMethod]
        public void TestMethodBilAfgiftUnder200000()
        {
            Afgift a = new Afgift();
            var acualResult = a.BilAfgift(180000);

            const double expectedResult = 153000;

            Assert.AreEqual(expectedResult, acualResult, 0.5,
                "ERROR: The expected result did not match the actual result.");
        }

        [TestMethod]
        public void TestMethodBilAfgiftOver200000()
        {
            Afgift a = new Afgift();
            var acualResult = a.BilAfgift(462000);

            const double expectedResult = 563000;

            Assert.AreEqual(expectedResult, acualResult, 0.5,
                "ERROR: The expected result did not match the actual result.");
        }

        [TestMethod]
        public void TestMethodElBilAfgiftUnder200000()
        {
            Afgift a = new Afgift();
            var acualResult = a.ElBilAfgift(180000);

            const double expectedResult = 30600;

            Assert.AreEqual(expectedResult, acualResult, 0.5,
                "ERROR: The expected result did not match the actual result.");
        }

        [TestMethod]
        public void TestMethodElBilAfgiftOver200000()
        {
            Afgift a = new Afgift();
            var acualResult = a.ElBilAfgift(462000);

            const double expectedResult = 112600;

            Assert.AreEqual(expectedResult, acualResult, 0.5,
                "ERROR: The expected result did not match the actual result.");
        }
    }
}
