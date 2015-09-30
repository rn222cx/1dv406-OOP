using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Workshop_2.Model
{
    class Member
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string SocialSecurityNumber { get; set; }

        public Member(string Name, string SocialSecurityNumber)
            : this(Name, SocialSecurityNumber, 0)
        {

        }

        public Member(string Name, string SocialSecurityNumber, int MemberID)
        {
            this.Name = Name;
            this.SocialSecurityNumber = SocialSecurityNumber;
            this.MemberID = MemberID;
        }
    }
}
