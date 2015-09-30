using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Workshop_2.Model
{
    class MemberDAL
    {
        public bool add(Member member)
        {
            try
            {
                if (File.Exists("Members.xml") == false)
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Indent = true;
                    xmlWriterSettings.NewLineOnAttributes = true;
                    using (XmlWriter xmlWriter = XmlWriter.Create("Members.xml", xmlWriterSettings))
                    {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("Members");

                        xmlWriter.WriteStartElement("Member");
                        xmlWriter.WriteElementString("id", "1");
                        xmlWriter.WriteElementString("Name", member.Name);
                        xmlWriter.WriteElementString("PersonalNumber", member.SocialSecurityNumber);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                        xmlWriter.Flush();
                        xmlWriter.Close();
                    }
                }
                else
                {
                    //XDocument xDocument = XDocument.Load("Members.xml");
                    //XElement Members = xDocument.Element("Members");
                    //IEnumerable<XElement> rows = Members.Descendants("Member");
                    //// get the last id value
                    //int id = int.Parse((string)Members.Descendants("id").FirstOrDefault());
                    //id++;
                    //XElement firstRow = rows.First();
                    //firstRow.AddBeforeSelf(
                    //   new XElement("Member",
                    //   new XElement("id", id),
                    //   new XElement("Name", Name),
                    //   new XElement("PersonalNumber", PersonalNumber)));
                    //xDocument.Save("Members.xml");

                    XElement xElement = XElement.Load("Members.xml");
                    int id = int.Parse((string)xElement.Descendants("id").FirstOrDefault());
                    id++;
                    xElement.AddFirst(new XElement("Member",
                       new XElement("id", id),
                       new XElement("Name", member.Name),
                       new XElement("PersonalNumber", member.SocialSecurityNumber)));
                    xElement.Save("Members.xml");
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool validateMemberID(int IdToValidate)
        {
            XElement xElement = XElement.Load("Members.xml");
            IEnumerable<XElement> members = xElement.Elements();
            foreach (var member in members)
            {
                if (member.Element("id").Value == IdToValidate.ToString())
                    return true;
            }

            return false;
        }
    }
}
