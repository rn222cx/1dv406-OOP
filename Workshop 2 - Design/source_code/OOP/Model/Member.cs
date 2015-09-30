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
        public string Name { get; set; }
        public string SocialSecurityNumber { get; set; }

        public Member(string name, string socialSecurityNumber)
        {
            Name = name;
            SocialSecurityNumber = socialSecurityNumber;
        }
    }
}
