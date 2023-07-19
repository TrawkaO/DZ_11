using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DZ_11
{
    internal class Program
    {
        public class Squad
        {
            public string squadName { get; set; }
            public string homeTown { get; set; }
            public int formed { get; set; }
            public string secretBase { get; set; }
            public bool active { get; set; }
            public Hero[] members { get; set; }

        }

        public class Hero
        {
            public string name { get; set; }
            public int age { get; set; }
            public string secretIdentity { get; set; }
            public string[] powers { get; set; }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Путь к папке с JSON doc");
          string folder = Console.ReadLine();
          if (!Directory.Exists(folder))
          {
              Console.WriteLine("Папки нет");
              return;
          }
            string[] files = Directory.GetFiles(folder);
            if (files.Length == 0)
            {
                Console.WriteLine("Нет файлов");
                return;
            }

            if (files.Length > 1)
            {
                Console.WriteLine("Больше одного файла");
            }

            string conJson = files.FirstOrDefault(f => f.EndsWith(".json"));
            if (conJson == null)
            {
                Console.WriteLine("Нет JSON ");
                return;
            }

            Console.WriteLine("Введите имя JSON файла:");
            string jsonFileName = Console.ReadLine();

            string jsonFilePath = Path.Combine(folder, jsonFileName);
            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine("Файл с таким именем нет.");
                return;
            }

            string json = File.ReadAllText(jsonFilePath);
             
            var squad = JsonSerializer.Deserialize<Squad>(json);
         

            var xmlDoc = new XDocument(
                new XElement("Squad",
                    
                    new XAttribute("squadName",squad.squadName),
                    new XAttribute("homeTown",squad.homeTown),
                    new XAttribute("formed", squad.formed),
                    new XAttribute("secretBase",squad.secretBase),
                    new XAttribute("active",squad.active),
                    new XElement("Heros", squad.members.Select(h => 
                        new XElement("Hero",
                            new XAttribute("Name",h.name),
                            new XAttribute("age",h.age),
                            new XAttribute("secretIdentity",h.secretIdentity),
                            new XElement("Powers",h.powers.Select(p => 
                                new XElement("Power",p))))))));
         

            string xmlName = $"{squad.squadName}_{squad.homeTown}_{squad.formed}_{squad.formed}_{squad.active}.xml";
            string xmlFile = Path.Combine(folder, xmlName);
            xmlDoc.Save(xmlFile);
           
            Console.WriteLine($"документ успешно распарсен по пути {xmlFile}.");



        }
    }
}