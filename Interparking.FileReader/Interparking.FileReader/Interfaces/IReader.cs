namespace Interparking.FileReader.Interfaces
{
    public interface IReader
    {
        string Read(string path);
        string Read(string path, bool decryptFile);
    }
}
