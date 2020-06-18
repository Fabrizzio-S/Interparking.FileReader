using Interparking.FileReader.Interfaces;
using Interparking.FileReader.Readers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Interparking.FileReader.Test
{
    [TestClass]
    public class TextReaderTest
    {
        #region Variables Declaration

        private IReader reader;

        #endregion

        #region Initialize

        [TestInitialize]
        public void TestInitialize()
        {
            reader = new TextReader();
        }

        #endregion

        #region Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadFile_PathNull_Test()
        {
            reader.Read(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadFile_PathEmpty_Test()
        {
            reader.Read("   ");
        }

        [TestMethod]
        public void ReadFile_Test()
        {
            string text = reader.Read(".\\ReadFile.txt");
            Assert.IsNotNull(text);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadXml_PathNull_Test()
        {
            reader.ReadXmlFile(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadXml_PathEmpty_Test()
        {
            reader.ReadXmlFile("   ");
        }

        [TestMethod]
        public void ReadXml_Test()
        {
            string xml = reader.ReadXmlFile(".\\ReadXml.xml");
            Assert.IsNotNull(xml);
        }

        #endregion
    }
}
