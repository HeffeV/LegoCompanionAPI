using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoCompanionAPI.Models
{
    public class Part
    {
        public long PartID { get; set; }
        public string PartName { get; set; }
        public int LegoCode { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }

        public ICollection<SetPart> SetParts { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
