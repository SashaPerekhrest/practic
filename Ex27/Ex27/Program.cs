using System;
using System.IO;
using System.Xml;

namespace Ex27
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles("Books");
            var fStr = new StreamWriter("otchet.txt", false);

            foreach (var book in files)
            {
                try
                { 
                    var doc = new XmlDocument();
                    doc.Load(book);

                    var title = doc.GetElementsByTagName("title-info")[0];
                    foreach (XmlNode tags in title)
                    {
                        if (tags.Name == "book-title")
                            fStr.Write($"Название: {tags.InnerText} ");
                        if (tags.Name == "author")
                            fStr.Write($"Автор: {tags["first-name"]?.InnerText} {tags["last-name"]?.InnerText} ");
                        if (tags.Name == "genre")
                            fStr.Write($"Жанр: {tags.InnerText} ");
                        if (tags.Name == "date")
                            fStr.Write($"Дата: {tags.InnerText} ");
                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); return; }
                fStr.WriteLine();
            }
            fStr.Close();
        }
    }
}