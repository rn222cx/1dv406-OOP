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

                XElement particularStudent = doc.Element(XMLFileInfo.Members).Elements(XMLFileInfo.Member)
                                    .Where(member => member.Element(XMLFileInfo.ID).Value == id.ToString())
                                    .Last();
                if (particularStudent != null)
                    particularStudent.Add(createBoat(boat));
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

                //memberToUpdate.Elements(XMLFileInfo.Boat)
                //    .Skip(boatsToBeSkipped).Take(1)
                //    .Remove();

                //memberToUpdate.Add(createBoat(boatToAdd));

                //XElement updatedMember = new XElement(XMLFileInfo.Member,
                //           new XElement(XMLFileInfo.ID, ID),
                //           new XElement(XMLFileInfo.Name, memberToBeReplaced.Element(XMLFileInfo.Name)),
                //           new XElement(XMLFileInfo.SocialSecurityNumber, memberToBeReplaced.Element(XMLFileInfo.SocialSecurityNumber)));

                //foreach (XElement element in memberToBeReplaced.Elements(XMLFileInfo.Boat))
                //{
                //    updatedMember.Add(element);

                //}

                //foreach (XElement element in updatedMember.Elements(XMLFileInfo.Boat))
                //{
                //    if (element.Attribute(XMLFileInfo.Type).ToString() == originalBoat.Type.ToString() && element.Value == originalBoat.Length)
                //    {

                //    }
                //}

                //memberToBeReplaced.ReplaceWith(updatedMember);

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

        public void removeBoat(int memberID, int boat)
        {

            XElement xElement = XElement.Load(XMLFileInfo.Path);
           
            xElement.Descendants(XMLFileInfo.Member)
                .Where(a => a.Element(XMLFileInfo.ID).Value == memberID.ToString())
                .SelectMany(a => a.Elements(XMLFileInfo.Boat))
                .Skip(boat).Take(1)
                .Remove();

            xElement.Save(XMLFileInfo.Path);
        }

        private XElement createBoat(Boat boat)
        {
            return new XElement(XMLFileInfo.Boat, boat.Length, new XAttribute(XMLFileInfo.Type, boat.Type));
        }
    }
}
