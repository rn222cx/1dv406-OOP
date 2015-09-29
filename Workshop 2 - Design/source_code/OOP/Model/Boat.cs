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
    }
}
