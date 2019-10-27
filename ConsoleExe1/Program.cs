using System;

namespace ConsoleExe1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0].Contains("read"))
            {
                string file_name = "C://Temp//" + args[1];
                FileHandler fHandler = new FileHandler(file_name);
                string content = fHandler.ReadFile();
                System.Console.WriteLine(content);
            }
            if (args[0].Contains("write"))
            {
                string file_name = "C://Temp//" + args[1];
                FileHandler fHandler = new FileHandler(file_name);
                fHandler.WriteFile(args[2]);
                System.Console.WriteLine("file written");
            }
        }
    }
}
