using System;
using System.Collections.Generic;
using DamsboSoftware.AlgorithmImplementations.Sorting;
using DamsboSoftware.AlgorithmImplementations.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DamsboSoftware.AlgorithmImplementations.SortingTests
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
            var radixSort = new RadixSort<sbyte>(new Calculator<sbyte>());
            sbytes = radixSort.Sort(sbytes);
            var expected = new List<sbyte> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, sbytes.Count);
            CollectionAssert.AreEqual(expected, sbytes);
        }

        [TestMethod]
        public void TestSortingBytesGeneric()
        {
            var bytes = new List<byte> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<byte>(new Calculator<byte>());
            bytes = radixSort.Sort(bytes);
            var expected = new List<byte> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, bytes.Count);
            CollectionAssert.AreEqual(expected, bytes);
        }

        [TestMethod]
        public void TestSortingCharsGeneric()
        {
            // TODO: Not yet implemented behaviour for non-integral type sorting
            var chars = new List<char> { 'h', 'q', 'a', 'y', 'n' };
            var radixSort = new RadixSort<char>(new Calculator<char>());
            chars = radixSort.Sort(chars);
            var expected = new List<char> { 'a', 'h', 'n', 'q', 'y' };
            Assert.AreEqual(expected.Count, chars.Count);
            CollectionAssert.AreEqual(expected, chars);
        }

        [TestMethod]
        public void TestSortingShortsGeneric()
        {
            var shorts = new List<short> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<short>(new Calculator<short>());
            shorts = radixSort.Sort(shorts);
            var expected = new List<short> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, shorts.Count);
            CollectionAssert.AreEqual(expected, shorts);
        }

        [TestMethod]
        public void TestSortingUShortsGeneric()
        {
            var ushorts = new List<ushort> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<ushort>(new Calculator<ushort>());
            ushorts = radixSort.Sort(ushorts);
            var expected = new List<ushort> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, ushorts.Count);
            CollectionAssert.AreEqual(expected, ushorts);
        }

        [TestMethod]
        public void TestSortingIntsGeneric()
        {
            var ints = new List<int> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<int>(new Calculator<int>());
            ints = radixSort.Sort(ints);
            var expected = new List<int> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, ints.Count);
            CollectionAssert.AreEqual(expected, ints);
        }

        [TestMethod]
        public void TestSortingUIntsGeneric()
        {
            var uints = new List<uint> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<uint>(new Calculator<uint>());
            uints = radixSort.Sort(uints);
            var expected = new List<uint> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, uints.Count);
            CollectionAssert.AreEqual(expected, uints);
        }

        [TestMethod]
        public void TestSortingLongsGeneric()
        {
            var longs = new List<long> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<long>(new Calculator<long>());
            longs = radixSort.Sort(longs);
            var expected = new List<long> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, longs.Count);
            CollectionAssert.AreEqual(expected, longs);
        }

        [TestMethod]
        public void TestSortingULongsGeneric()
        {
            var ulongs = new List<ulong> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<ulong>(new Calculator<ulong>());
            ulongs = radixSort.Sort(ulongs);
            var expected = new List<ulong> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, ulongs.Count);
            CollectionAssert.AreEqual(expected, ulongs);
        }

        [TestMethod]
        public void TestSortingFloatsGeneric()
        {
            // TODO: Not yet implemented behaviour for non-integral type sorting
            var floats = new List<float> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<float>(new Calculator<float>());
            floats = radixSort.Sort(floats);
            var expected = new List<float> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, floats.Count);
            CollectionAssert.AreEqual(expected, floats);
        }

        [TestMethod]
        public void TestSortingDoublesGeneric()
        {
            // TODO: Not yet implemented behaviour for non-integral type sorting
            var doubles = new List<double> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<double>(new Calculator<double>());
            doubles = radixSort.Sort(doubles);
            var expected = new List<double> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, doubles.Count);
            CollectionAssert.AreEqual(expected, doubles);
        }

        [TestMethod]
        public void TestSortingDecimalsGeneric()
        {
            // TODO: Not yet implemented behaviour for non-integral type sorting
            var decimals = new List<decimal> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<decimal>(new Calculator<decimal>());
            decimals = radixSort.Sort(decimals);
            var expected = new List<decimal> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, decimals.Count);
            CollectionAssert.AreEqual(expected, decimals);
        }

        [TestMethod]
        public void TestSortingIntsVaryingSizesGeneric()
        {
            var rnd = new Random(2141);

            for (int i = 5; i <= 8; i++)
            {
                var amount = (int) Math.Pow(2, i);
                var ints = new List<int>(amount);
                
                for (int j = 0; j < ints.Capacity; j++)
                {
                    ints.Add(rnd.Next());
                }
                var expected = new List<int>(amount);
                expected.Sort();

                var radixSort = new RadixSort<int>(new Calculator<int>());
                ints = radixSort.Sort(ints);
                
                Assert.AreEqual(expected.Count, ints.Count);
                CollectionAssert.AreEqual(expected, ints);

            }
        }
    }
}
