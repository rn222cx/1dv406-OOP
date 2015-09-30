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
        public BoatType Type { get; set; }
        public string Length { get; set; }
        public Boat(BoatType Type, string Length)
        {
            this.Type = Type;
            this.Length = Length;
        }
    }
}
