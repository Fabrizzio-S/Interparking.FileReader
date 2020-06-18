using Interparking.FileReader.Interfaces;
using Interparking.FileReader.Readers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Interparking.FileReader.Test
{
    [TestClass]
    public class XmlReaderTest
    {
        #region Variables Declaration

        private IReader reader;

        #endregion

        #region Initialize

        [TestInitialize]
        public void TestInitialize()
        {
            reader = new XmlReader();
        }

        #endregion

        #region Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadXml_PathNull_Test()
        {
            reader.Read(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadXml_PathEmpty_Test()
        {
            reader.Read("   ");
        }

        [TestMethod]
        public void ReadXml_Test()
        {
            string xml = reader.Read(".\\ReadXml.xml");
            Assert.IsNotNull(xml);
        }

        #endregion
    }
}
