using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoCompanionAPI.Models
{
    public class SetPart
    {
        public long SetPartID { get; set; }
        public long? SetID { get; set; }
        public long? PartID { get; set; }
        public Set Set { get; set; }
        public Part Part { get; set; }
        public int Amount { get; set; }
    }
}
