using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DjeLibrary_2.Data.Collections
{
    [TestClass]
    public class ListHelperTest
    {
        [TestMethod]
        public void converts_list_to_string()
        {
            List<string> listToDisplay = new List<string>();
            listToDisplay.Add("a");
            listToDisplay.Add("b");
            listToDisplay.Add("c");

            string result = ListHelper.ToString(listToDisplay);

            Assert.AreEqual("[a;b;c]", result);
        }

        [TestMethod]
        public void converts_null_to_string_returns_empty()
        {
            string result = ListHelper.ToString(null);

            Assert.AreEqual("[]", result);
        }
    }
}
