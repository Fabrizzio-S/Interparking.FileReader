using Interparking.FileReader.Interfaces;
using System;
using System.IO;

namespace Interparking.FileReader.Readers
{
    public class TextReader : IReader
    {
        #region IReader Implementation

        public string Read(string path)
        {
            VerifyPath(path);
            return File.ReadAllText(path);
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
