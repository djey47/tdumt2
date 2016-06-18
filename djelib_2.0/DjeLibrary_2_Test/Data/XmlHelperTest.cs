using System;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DjeLibrary_2.Data
{
    [TestClass]
    public class XmlHelperTest
    {
        [TestMethod]
        public void get_existing_attribute()
        {
            XmlDocument xmlDocument = _LoadTestDocument();
            XmlNode node = xmlDocument.SelectSingleNode("//childOne");

            string result = XmlHelper.GetAttributeWithDefaultValue(node, "attributeOne", "bla");

            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void get_nonexisting_attribute_with_default_value()
        {
            XmlDocument xmlDocument = _LoadTestDocument();
            XmlNode node = xmlDocument.SelectSingleNode("//childOne");

            string result = XmlHelper.GetAttributeWithDefaultValue(node, "attribute", "bla");

            Assert.AreEqual("bla", result);
        }

        private XmlDocument _LoadTestDocument()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlReader reader = new XmlTextReader(@"Resources\xml.xml");
            xmlDocument.Load(reader);
            return xmlDocument;
        }
    }
}
