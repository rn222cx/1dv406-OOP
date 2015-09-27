using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP
{
    class Boat
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Length { get; set; }
        public Boat(int id, string type, string length)
        {
            Id = id;
            Type = type;
            Length = length;
        }

        public void add() // bara massa skit jag har testat i denna metod, inget nyttigt att veta
        {
            // To add an attribute to an Element, use the following code:

            //XElement xEle = XElement.Load("Members.xml");
            //xEle.Add(new XElement("Employee",
            //    new XElement("EmpId", 5),
            //    new XElement("Phone", "423-555-4224", new XAttribute("Type", "Home"))));
            //xEle.Save("Members.xml");

            //Console.Write(xEle);


            //Count the number of Employees living in the state CA

            //XElement xelement = XElement.Load("..\\..\\Employees.xml");
            //var stCnt = from address in xelement.Elements("Employee")
            //            where (string)address.Element("Address").Element("State") == "CA"
            //            select address;
            //Console.WriteLine("No of Employees living in CA State are {0}", stCnt.Count());
        }
    }
}
