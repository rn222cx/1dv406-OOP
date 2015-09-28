using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Workshop_2.Model
{
    class Boat
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Length { get; set; }
        public Boat(string id, string type, string length)
        {
            Id = id;
            Type = type;
            Length = length;
        }

        public void add()
        {

            //Count the number of Employees living in the state CA

            //XElement xelement = XElement.Load("..\\..\\Employees.xml");
            //var stCnt = from address in xelement.Elements("Employee")
            //            where (string)address.Element("Address").Element("State") == "CA"
            //            select address;
            //Console.WriteLine("No of Employees living in CA State are {0}", stCnt.Count());

            XDocument doc = XDocument.Load("Members.xml");

            XElement particularStudent = doc.Element("Members").Elements("Member")
                                .Where(member => member.Element("id").Value == Id)
                                .Last();
            if (particularStudent != null)
                particularStudent.Add(new XElement("Boat", Length, new XAttribute("Type", Type)));
            doc.Save("Members.xml");
            Console.WriteLine(doc);
            Console.ReadLine();

        }
    }
}
