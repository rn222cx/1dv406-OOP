using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Workshop_2.Model
{
    class BoatDAL
    {
        public bool add(Boat boat)
        {
            try
            {
                XDocument doc = XDocument.Load("Members.xml");

                XElement particularStudent = doc.Element("Members").Elements("Member")
                                    .Where(member => member.Element("id").Value == boat.Id)
                                    .Last();
                if (particularStudent != null)
                    particularStudent.Add(new XElement("Boat", boat.Length, new XAttribute("Type", boat.Type)));
                doc.Save("Members.xml");
                Console.WriteLine(doc);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
