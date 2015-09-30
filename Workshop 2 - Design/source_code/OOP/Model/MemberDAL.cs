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
                if (File.Exists(XMLFileInfo.Path) == false)
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Indent = true;
                    xmlWriterSettings.NewLineOnAttributes = true;
                    using (XmlWriter xmlWriter = XmlWriter.Create(XMLFileInfo.Path, xmlWriterSettings))
                    {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement(XMLFileInfo.Members);

                        xmlWriter.WriteStartElement(XMLFileInfo.Member);
                        xmlWriter.WriteElementString(XMLFileInfo.ID, XMLFileInfo.FirstID);
                        xmlWriter.WriteElementString(XMLFileInfo.Name, member.Name);
                        xmlWriter.WriteElementString(XMLFileInfo.SocialSecurityNumber, member.SocialSecurityNumber);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                        xmlWriter.Flush();
                        xmlWriter.Close();
                    }
                }
                else
                {
                    XElement xElement = XElement.Load(XMLFileInfo.Path);
                    int id = int.Parse((string)xElement.Descendants(XMLFileInfo.ID).FirstOrDefault());
                    id++;
                    xElement.AddFirst(new XElement(XMLFileInfo.Member,
                       new XElement(XMLFileInfo.ID, id),
                       new XElement(XMLFileInfo.Name, member.Name),
                       new XElement(XMLFileInfo.SocialSecurityNumber, member.SocialSecurityNumber)));
                    xElement.Save(XMLFileInfo.Path);
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
            XElement xElement = XElement.Load(XMLFileInfo.Path);
            IEnumerable<XElement> members = xElement.Elements();
            foreach (var member in members)
            {
                if (member.Element(XMLFileInfo.ID).Value == IdToValidate.ToString())
                    return true;
            }

            return false;
        }

        public Member getMemberByID(int memberID)
        {
            XElement xElement = XElement.Load(XMLFileInfo.Path);

            var memberInfo = from Member in xElement.Elements(XMLFileInfo.Member)
                                where (string)Member.Element(XMLFileInfo.ID) == memberID.ToString()
                                select Member;

            var memberNames = memberInfo.Elements(XMLFileInfo.Name);
            XElement memberName = memberNames.First();

            var memberSSNs = memberInfo.Elements(XMLFileInfo.SocialSecurityNumber);
            XElement memberSSN = memberSSNs.First();

            return new Member(memberName.Value, memberSSN.Value);
        }
    }
}
