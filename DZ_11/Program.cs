using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using static DZ_11.Reed;

namespace DZ_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Путь к папке с JSON doc");
            string folder = Console.ReadLine();
            var squad = Json.ParseJson(folder);
            SaveXML.SaveXml(squad,folder);

        }
    }
}