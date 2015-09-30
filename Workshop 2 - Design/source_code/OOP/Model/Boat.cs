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
        // TODO: TEAM -> What ID is this? Is it the Members ID? In that case, shouldn't we add both the Member ID and the Boat to the BoatDAL in order to avoid using PK in the class?
        //public string Id { get; set; }
        public string Type { get; set; }
        public string Length { get; set; }
        public Boat(string type, string length)
        {
            //Id = id;
            Type = type;
            Length = length;
        }
    }
}
