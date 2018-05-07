using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

namespace _Tests.Sorting
{
    [TestClass]
    public class UnitTestRadix
    {
        [TestMethod]
        public void TestSortingIntsNonGeneric()
        {
            var ints = new List<int> { 3, 5, 1, 8, 2 };
            ints = RadixSort.Sort(ints);
            var expected = new List<int> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, ints.Count);
            for (int i = 0; i < ints.Count; i++)
            {
                Assert.AreEqual(expected[i], ints[i]);
            }
        }

        [TestMethod]
        public void TestSortingSBytesGeneric()
        {
            var sbytes = new List<sbyte> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<sbyte>(new SByte.Calculator());
            sbytes = radixSort.Sort(sbytes);
            var expected = new List<sbyte> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, sbytes.Count);
            for (int i = 0; i < sbytes.Count; i++)
            {
                Assert.AreEqual(expected[i], sbytes[i]);
            }
        }

        [TestMethod]
        public void TestSortingBytesGeneric()
        {
            var bytes = new List<byte> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<byte>(new Byte.Calculator());
            bytes = radixSort.Sort(bytes);
            var expected = new List<byte> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, bytes.Count);
            for (int i = 0; i < bytes.Count; i++)
            {
                Assert.AreEqual(expected[i], bytes[i]);
            }
        }

        [TestMethod]
        public void TestSortingCharsGeneric()
        {
            var chars = new List<char> { 'h', 'q', 'a', 'y', 'n' };
            var radixSort = new RadixSort<char>(new Char.Calculator());
            chars = radixSort.Sort(chars);
            var expected = new List<char> { 'a', 'h', 'n', 'q', 'y' };
            Assert.AreEqual(expected.Count, chars.Count);
            for (int i = 0; i < chars.Count; i++)
            {
                Assert.AreEqual(expected[i], chars[i]);
            }
        }

        [TestMethod]
        public void TestSortingShortsGeneric()
        {
            var shorts = new List<short> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<short>(new Short.Calculator());
            shorts = radixSort.Sort(shorts);
            var expected = new List<short> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, shorts.Count);
            for (int i = 0; i < shorts.Count; i++)
            {
                Assert.AreEqual(expected[i], shorts[i]);
            }
        }

        [TestMethod]
        public void TestSortingUShortsGeneric()
        {
            var ushorts = new List<ushort> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<ushort>(new UShort.Calculator());
            ushorts = radixSort.Sort(ushorts);
            var expected = new List<ushort> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, ushorts.Count);
            for (int i = 0; i < ushorts.Count; i++)
            {
                Assert.AreEqual(expected[i], ushorts[i]);
            }
        }

        [TestMethod]
        public void TestSortingIntsGeneric()
        {
            var ints = new List<int> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<int>(new Int32.Calculator());
            ints = radixSort.Sort(ints);
            var expected = new List<int> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, ints.Count);
            for (int i = 0; i < ints.Count; i++)
            {
                Assert.AreEqual(expected[i], ints[i]);
            }
        }

        [TestMethod]
        public void TestSortingUIntsGeneric()
        {
            var units = new List<uint> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<uint>(new UInt.Calculator());
            units = radixSort.Sort(units);
            var expected = new List<uint> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, units.Count);
            for (int i = 0; i < units.Count; i++)
            {
                Assert.AreEqual(expected[i], units[i]);
            }
        }

        [TestMethod]
        public void TestSortingLongsGeneric()
        {
            var longs = new List<long> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<long>(new Long.Calculator());
            longs = radixSort.Sort(longs);
            var expected = new List<long> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, longs.Count);
            for (int i = 0; i < longs.Count; i++)
            {
                Assert.AreEqual(expected[i], longs[i]);
            }
        }

        [TestMethod]
        public void TestSortingULongsGeneric()
        {
            var ulongs = new List<ulong> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<ulong>(new ULong.Calculator());
            ulongs = radixSort.Sort(ulongs);
            var expected = new List<ulong> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, ulongs.Count);
            for (int i = 0; i < ulongs.Count; i++)
            {
                Assert.AreEqual(expected[i], ulongs[i]);
            }
        }

        [TestMethod]
        public void TestSortingFloatsGeneric()
        {
            var floats = new List<float> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<float>(new Float.Calculator());
            floats = radixSort.Sort(floats);
            var expected = new List<float> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, floats.Count);
            for (int i = 0; i < floats.Count; i++)
            {
                Assert.AreEqual(expected[i], floats[i]);
            }
        }

        [TestMethod]
        public void TestSortingDoublesGeneric()
        {
            var doubles = new List<double> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<double>(new Double.Calculator());
            doubles = radixSort.Sort(doubles);
            var expected = new List<double> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, doubles.Count);
            for (int i = 0; i < doubles.Count; i++)
            {
                Assert.AreEqual(expected[i], doubles[i]);
            }
        }

        [TestMethod]
        public void TestSortingDecimalsGeneric()
        {
            var decimals = new List<decimal> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<decimal>(new Decimal.Calculator());
            decimals = radixSort.Sort(decimals);
            var expected = new List<decimal> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, decimals.Count);
            for (int i = 0; i < decimals.Count; i++)
            {
                Assert.AreEqual(expected[i], decimals[i]);
            }
        }
    }
}
