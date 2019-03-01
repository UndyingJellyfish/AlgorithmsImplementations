using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberTheory;

namespace NumberTheoryTest
{
    [TestClass]
    public class DivisorsTests
    {
        [TestMethod]
        public void TestGetListOfDivisors1()
        {
            var expected = new List<int>
            {
                1
            };
            var output = Divisors.GetListOfDivisors(1);

            CollectionAssert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestGetListOfDivisors2()
        {
            var expected = new List<int>
            {
                1,
                2
            };
            var output = Divisors.GetListOfDivisors(2);

            CollectionAssert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestGetListOfDivisors7()
        {
            var expected = new List<int>
            {
                1,
                7
            };
            var output = Divisors.GetListOfDivisors(7);

            CollectionAssert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestGetListOfDivisors12()
        {
            var expected = new List<int>
            {
                1,
                2,
                3,
                4,
                6,
                12
            };
            var output = Divisors.GetListOfDivisors(12);

            CollectionAssert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestGetListOfDivisors37()
        {
            var expected = new List<int>
            {
                1,
                37
            };

            var output = Divisors.GetListOfDivisors(37);

            CollectionAssert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestGetListOfDivisors5040()
        {
            var expected = new List<int>
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 15, 16, 18, 20,
                21, 24, 28, 30, 35, 36, 40, 42, 45, 48, 56, 60, 63, 70,
                72, 80, 84, 90, 105, 112, 120, 126, 140, 144, 168, 180,
                210, 240, 252, 280, 315, 336, 360, 420, 504, 560, 630,
                720, 840, 1008, 1260, 1680, 2520, 5040
            };
            var output = Divisors.GetListOfDivisors(5040);

            CollectionAssert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestMostDivisibleNumberMin1Max1()
        {
            var expected = 1;
            var output = Divisors.MostDivisibleNumber(1,1).Result;

            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestMostDivisibleNumberMin0Max12()
        {
            var expected = 12;
            var output = Divisors.MostDivisibleNumber(0, 12).Result;

            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestMostDivisibleNumberMax12()
        {
            var expected = 12;
            var output = Divisors.MostDivisibleNumber(12).Result;

            Assert.AreEqual(expected, output);
        }
    }
}
