using Interparking.FileReader.Interfaces;
using System;
using System.Xml;

namespace Interparking.FileReader.Readers
{
    public class XmlReader : IReader
    {
        #region IReader Implementation

        public string Read(string path)
        {
            VerifyPath(path);

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            return xmlDocument.InnerXml;
        }

        public string Read(string path, bool decryptFile)
        {
            throw new NotImplementedException();
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
