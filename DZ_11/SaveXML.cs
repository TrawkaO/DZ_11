using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DZ_11
{
    internal class SaveXML
    {
        
        public static void SaveXml(Squad squad, string folder)
        {

            var xmlDoc = new XDocument(
                new XElement("Squad",

                    new XAttribute("squadName", squad.squadName),
                    new XAttribute("homeTown", squad.homeTown),
                    new XAttribute("formed", squad.formed),
                    new XAttribute("secretBase", squad.secretBase),
                    new XAttribute("active", squad.active),
                    new XElement("Heros", squad.members.Select(h =>
                        new XElement("Hero",
                            new XAttribute("Name", h.name),
                            new XAttribute("age", h.age),
                            new XAttribute("secretIdentity", h.secretIdentity),
                            new XElement("Powers", h.powers.Select(p =>
                                new XElement("Power", p))))))));


            string xmlName = $"{squad.squadName}_{squad.homeTown}_{squad.formed}_{squad.formed}_{squad.active}.xml";
            string xmlFile = Path.Combine(folder, xmlName);
            xmlDoc.Save(xmlFile);
            Console.WriteLine($"документ успешно распарсен по пути {xmlFile}.");

        }
    }
}
