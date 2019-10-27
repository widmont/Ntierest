using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleExe1
{
    class FileHandler
    {
        private string file_name;

        public FileHandler(string file_name)
        {
            // TODO Auto-generated constructor stub
            this.file_name = file_name;
        }

        public string ReadFile()
        {
            string content = "";

            if (System.IO.File.Exists(file_name) == true)
            {
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader(file_name);
                content = objReader.ReadLine();
                objReader.Close();
            }
            else
            {
                content = "No such file " + file_name;
            }

            return content;
        }

        public void WriteFile(string text)
        {
            System.IO.StreamWriter objWriter;
            objWriter = new System.IO.StreamWriter(file_name);
            objWriter.Write(text);
            objWriter.Close();
        }
    }
}
