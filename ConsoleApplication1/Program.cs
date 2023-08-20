using System;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using System.Security.Policy;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args) {
            // Create a directory, if doesnt exist.
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Files";
            Directory.CreateDirectory(path);

            // Create/attach to the 1.txt file
            string filename = path + "\\1.txt";
            StreamWriter sw = File.AppendText(filename);
            sw.WriteLine("testing");
            sw.Flush();
            sw.Close();
            // Rename it...
            File.Move(filename, path + "\\2.txt");

            // Create a new 1.txt
            sw = File.AppendText(filename);
            FileInfo fi = new FileInfo(filename);
            // Observe, the old files creation date!!
            Console.WriteLine(String.Format("Date: {0}", fi.CreationTime.Date));

            Console.ReadKey();
        }
    }
}
