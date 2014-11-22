using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TroyFillerupChallenge01;
using System.Collections.Generic;

namespace TroyFillerupChalleng01Tests
{
    [TestClass]
    public class SorterTests
    {
        [TestMethod]
        public void Sort_CommaDelimetedString_ShouldReturnCorrectList()
        {
            var testList = "a1,a9,b1,a2,c3,b6,a19,d2";
            var expected = new List<string>(){"a1", "a2", "a9", "a19", "b1", "b6", "c3", "d2"};
            var sorter = new Sorter();
            var output = sorter.Sort(testList);

            CollectionAssert.AreEqual(output, expected);

        }

        [TestMethod]
        public void Sort_CommaDelimetedString2_ShouldReturnCorrectList()
        {
            var testList = "a1,b1,a20,a2,a12,c5";
            var expected = new List<string>() { "a1", "a2", "a12", "a20", "b1", "c5" };
            var sorter = new Sorter();
            var output = sorter.Sort(testList);

            CollectionAssert.AreEqual(output, expected);

        }

        [TestMethod]
        public void Sort_StringList_ShouldReturnCorrectList()
        {
            var testList = new List<string>() { "a1", "a9", "b1", "a2", "c3", "b6", "a19", "d2" };
            var expected = new List<string>() { "a1", "a2", "a9", "a19", "b1", "b6", "c3", "d2" };
            var sorter = new Sorter();
            var output = sorter.Sort(testList);

            CollectionAssert.AreEqual(output, expected);

        }

    }
}
