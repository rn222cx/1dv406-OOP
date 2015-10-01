using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Workshop_2.Model
{
    class BoatDAL : BaseDAL
    {
        public bool add(int id, Boat boat)
        {
            try
            {
                XDocument doc = XDocument.Load(XMLFileInfo.Path);

                XElement particularStudent = doc.Element(XMLFileInfo.Members).Elements(XMLFileInfo.Member)
                                    .Where(member => member.Element(XMLFileInfo.ID).Value == id.ToString())
                                    .Last();
                if (particularStudent != null)
                    particularStudent.Add(new XElement(XMLFileInfo.Boat, boat.Length, new XAttribute(XMLFileInfo.Type, boat.Type)));
                doc.Save(XMLFileInfo.Path);
                Console.WriteLine(doc);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Boat> getBoatsByMemberID(int memberID)
        {
            List<Boat> boats = new List<Boat>();

            XElement xElement = XElement.Load(XMLFileInfo.Path);

            var memberInfo = from Member in xElement.Elements(XMLFileInfo.Member)
                             where (string)Member.Element(XMLFileInfo.ID) == memberID.ToString()
                             select Member;

            XElement member = memberInfo.First();
            
            foreach (XElement boat in member.Elements(XMLFileInfo.Boat))
            {
                BoatType type = (BoatType)Enum.Parse(typeof(BoatType), boat.Attribute(XMLFileInfo.Type).Value);
                var boatToBeAdded = new Boat(type, boat.Value);
                boats.Add(boatToBeAdded);
            }

            boats.TrimExcess();

            return boats;
        }
    }
}
