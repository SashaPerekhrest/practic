using System;
using System.IO;
using System.Text;

namespace Ex20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var fileToCopy = File.ReadAllText("fileToOpen.txt", Encoding.UTF8);
            Console.WriteLine(fileToCopy);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            File.WriteAllText("windows", fileToCopy, Encoding.GetEncoding(1251));
            File.WriteAllText("dos", fileToCopy, Encoding.GetEncoding(866));
        }
    }
}