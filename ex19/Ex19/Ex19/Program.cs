using System;
using System.IO;

namespace Ex19
{
    class Program
    {
        static void Main(string[] args)
        {
            var arguments = Console.ReadLine().Split(" ");
            var location = arguments[0];
            var firstFile = arguments[1];
            var secondFile = arguments[2];
            
            var fileToCopy = new FileInfo(location + firstFile);
            fileToCopy.CopyTo(location + secondFile);
            Console.WriteLine("Hello World!");
        }
    }
}