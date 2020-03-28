using System;
using System.IO;
using System.Text;

namespace ProductInventory.DataContext
{
    public class FileReadWrite : IFileReadWrite
    {
        private string filePath { get; set; }

        public FileReadWrite(string filePath)
        {
            
          this.filePath = filePath;
           
        }

        public void WriteToFile(string text)
        {
            try {

                Byte[] info = new UTF8Encoding(true).GetBytes(text);

                using (var file = new FileStream(this.filePath, FileMode.Create, FileAccess.Write))
                {
                    file.Write(info, 0, info.Length);
                }
             }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void AppendToFile(string text)
        {
            try
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(text);

                using (var file = new FileStream(this.filePath, FileMode.Append, FileAccess.Write))
                {
                    file.Write(info, 0, info.Length);

                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string ReadFromFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(this.filePath))
                {
                    var text = sr.ReadToEnd();

                    return text;
                   
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

