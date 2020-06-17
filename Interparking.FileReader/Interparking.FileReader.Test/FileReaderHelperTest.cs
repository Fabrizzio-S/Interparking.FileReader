using Interparking.FileReader.Helpers;
using Interparking.FileReader.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Interparking.FileReader.Test
{
    [TestClass]
    public class FileReaderHelperTest
    {
        #region Variables Declaration

        private IFileReaderHelper fileReaderHelper;

        #endregion

        #region Initialize

        [TestInitialize]
        public void TestInitialize()
        {
            fileReaderHelper = new FileReaderHelper();
        }

        #endregion

        #region Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadFile_PathNull_Test()
        {
            fileReaderHelper.ReadFile(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadFile_PathEmpty_Test()
        {
            fileReaderHelper.ReadFile("   ");
        }

        [TestMethod]
        public void ReadFile_Test()
        {
            string text = fileReaderHelper.ReadFile(".\\ReadFile.txt");
            Assert.IsNotNull(text);
        }

        #endregion
    }
}
