using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DjeLibrary_2.Data
{
    [TestClass]
    public class StringHelperTest
    {
        [TestMethod]
        public void converts_string_to_pascal_case()
        {
            string result = StringHelper.ToPascalCase("azertyAZERTY");
            Assert.AreEqual("AzertyAZERTY", result);
        }

        [TestMethod]
        public void converts_null_to_pascal_case_returns_null()
        {
            string result = StringHelper.ToPascalCase(null);
            Assert.IsNull(result);
        }
    }
}
