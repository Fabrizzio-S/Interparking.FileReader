using Interparking.FileReader.Interfaces;
using System;
using System.IO;

namespace Interparking.FileReader.Helpers
{
    public class FileReaderHelper : IFileReaderHelper
    {
        public string ReadFile(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException($"{nameof(path)} should not be null");
            }
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException($"{nameof(path)} should not be empty");
            }
            return File.ReadAllText(path);
        }
    }
}
