using Interparking.FileReader.Interfaces;
using System;
using System.IO;

namespace Interparking.FileReader.Readers
{
    public class TextReader : IReader
    {
        #region Variables Declaration

        private readonly IEncryption encryption;

        #endregion

        #region Constructor

        public TextReader(IEncryption encryption)
        {
            this.encryption = encryption;
        }

        #endregion

        #region IReader Implementation

        public string Read(string path)
        {
            VerifyPath(path);
            return File.ReadAllText(path);
        }

        public string Read(string path, bool decryptFile)
        {
            string text = Read(path);
            if (!decryptFile)
            {
                return text;
            }
            return encryption.Decrypt(text);
        }

        #endregion

        #region Business

        #region Private

        private void VerifyPath(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException($"{nameof(path)} should not be null");
            }
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException($"{nameof(path)} should not be empty");
            }
        }

        #endregion

        #endregion
    }
}
