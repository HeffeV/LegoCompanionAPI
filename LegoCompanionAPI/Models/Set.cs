using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoCompanionAPI.Models
{
    public class Set
    {
        public long SetID { get; set; }
        public string SetName { get; set; }
        public int LegoCode { get; set; }
        public int Age { get; set; }
        public int Pieces { get; set; }
        public double Price { get; set; }
        public string Theme { get; set; }
        public int ReleaseYear { get; set; }
        public long? DimensionsID { get; set; }


        public Dimensions Dimensions { get; set; }
        public ICollection<SetPart> SetParts { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
