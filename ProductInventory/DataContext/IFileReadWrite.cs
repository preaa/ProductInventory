using System;
namespace ProductInventory.DataContext
{
    public interface IFileReadWrite
    {

        public void WriteToFile(string text);

        public void AppendToFile(string text);

        public string ReadFromFile();
    }
}
