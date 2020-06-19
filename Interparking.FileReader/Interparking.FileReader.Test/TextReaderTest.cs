using Interparking.FileReader.Interfaces;
using Interparking.FileReader.Readers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Interparking.FileReader.Test
{
    [TestClass]
    public class TextReaderTest
    {
        #region Variables Declaration

        private IReader reader;
        private readonly string contentText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Velit scelerisque in dictum non consectetur a erat. Sit amet justo donec enim diam vulputate. Id aliquet lectus proin nibh nisl condimentum id venenatis a. Eget gravida cum sociis natoque penatibus et magnis dis. Habitant morbi tristique senectus et netus et. Interdum consectetur libero id faucibus nisl tincidunt eget nullam. Aliquam purus sit amet luctus. Fringilla ut morbi tincidunt augue interdum velit. Neque sodales ut etiam sit. Quam viverra orci sagittis eu volutpat odio facilisis mauris. Ornare suspendisse sed nisi lacus sed. Iaculis at erat pellentesque adipiscing commodo elit at imperdiet dui. Quam nulla porttitor massa id neque aliquam vestibulum morbi. Dignissim diam quis enim lobortis scelerisque fermentum dui faucibus. Turpis egestas integer eget aliquet.";

        #endregion

        #region Initialize

        [TestInitialize]
        public void TestInitialize()
        {
            Mock<IEncryption> encryctionMock = new Mock<IEncryption>();
            encryctionMock.Setup(x => x.Decrypt(It.IsAny<string>())).Returns((string x) => Reverse(x));
            reader = new TextReader(encryctionMock.Object);
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
            Assert.IsTrue(string.Equals(text, contentText));
        }

        [TestMethod]
        public void ReadFile_Encrypted_Test()
        {
            string text = reader.Read(".\\ReadFileReversed.txt", true);
            Assert.IsNotNull(text);
            Assert.IsTrue(string.Equals(text, contentText));
        }

        #endregion

        #region Business

        #region Priavete

        private string Reverse(string text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        #endregion

        #endregion
    }
}
