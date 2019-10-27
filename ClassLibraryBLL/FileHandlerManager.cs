using System;
using ClassLibraryDAL;

namespace ClassLibraryBLL
{
    public class FileHandlerManager
    {

        private string filename;

        public FileHandlerManager(string filename)
        {
            this.filename = filename;
        }

        public void Write(string content)
        {
            FileHandlerDB FhDB = new FileHandlerDB();
            try
            {
                FhDB.AddContent(filename, content);
            }
            catch
            {
                FileHandler Fh = new FileHandler(filename);
                Fh.WriteFile(filename, content);
            }
        }

        public string Read()
        {
            FileHandlerDB FhDB = new FileHandlerDB();
            string result;
            try
            {
                result = FhDB.GetContent(filename);
            }
            catch
            {
                FileHandler Fh = new FileHandler(filename);
                result = Fh.ReadFile();
            }
            return result;
        }
    }
}

