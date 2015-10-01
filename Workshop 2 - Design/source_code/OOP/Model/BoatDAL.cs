using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Workshop_2.Model
{
    class BoatDAL
    {
        public bool add(int id, Boat boat)
        {
            try
            {
                XDocument doc = XDocument.Load(XMLFileInfo.Path);

                XElement particularMember = doc.Element(XMLFileInfo.Members).Elements(XMLFileInfo.Member)
                                    .Where(member => member.Element(XMLFileInfo.ID).Value == id.ToString())
                                    .Last();
                if (particularMember != null)
                    particularMember.Add(createBoat(boat));
                doc.Save(XMLFileInfo.Path);
                Console.WriteLine(doc);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool updateBoat(int memberID, int boatsToBeSkipped, Boat boatToAdd)
        {
            try
            {
                XElement xElement = XElement.Load(XMLFileInfo.Path);

                XElement memberToUpdate = (from Member in xElement.Elements(XMLFileInfo.Member)
                                               where (string)Member.Element(XMLFileInfo.ID) == memberID.ToString()
                                               select Member).First();

                XElement boat = memberToUpdate.Elements(XMLFileInfo.Boat)
                    .Skip(boatsToBeSkipped)
                    .Take(1)
                    .First();

                boat.ReplaceWith(createBoat(boatToAdd));
                
                xElement.Save(XMLFileInfo.Path);

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

        public bool removeBoat(int memberID, int boat)
        {
            try
            {
                XElement xElement = XElement.Load(XMLFileInfo.Path);

                xElement.Descendants(XMLFileInfo.Member)
                    .Where(a => a.Element(XMLFileInfo.ID).Value == memberID.ToString())
                    .SelectMany(a => a.Elements(XMLFileInfo.Boat))
                    .Skip(boat).Take(1)
                    .Remove();

                xElement.Save(XMLFileInfo.Path);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private XElement createBoat(Boat boat)
        {
            return new XElement(XMLFileInfo.Boat, boat.Length, new XAttribute(XMLFileInfo.Type, boat.Type));
        }
    }
}
