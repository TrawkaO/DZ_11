using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DZ_11
{
    internal class Reed
    {
        public class Json
        {
            public static Squad ParseJson(string folder)
            {

                if (!Directory.Exists(folder))
                {
                    Console.WriteLine("Папки нет");
                    return null;
                }
                string[] files = Directory.GetFiles(folder);
                if (files.Length == 0)
                {
                    Console.WriteLine("Нет файлов");
                    return null;
                }

                if (files.Length > 1)
                {
                    Console.WriteLine("Больше одного файла");
                }

                string conJson = files.FirstOrDefault(f => f.EndsWith(".json"));
                if (conJson == null)
                {
                    Console.WriteLine("Нет JSON ");
                    return null;
                }

                Console.WriteLine("Введите имя JSON файла:");
                string jsonFileName = Console.ReadLine();

                string jsonFilePath = Path.Combine(folder, jsonFileName);
                if (!File.Exists(jsonFilePath))
                {
                    Console.WriteLine("Файл с таким именем нет.");
                    return null;
                }

                string json = File.ReadAllText(jsonFilePath);

                var squad = JsonSerializer.Deserialize<Squad>(json);


                return squad;
            }
        }
    }
}


