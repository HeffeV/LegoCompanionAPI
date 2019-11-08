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
        public int LegoCode { get; set; }
        public int Age { get; set; }
        public int Pieces { get; set; }
        public double Price { get; set; }
        public Theme Theme { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseDate { get; set; }

        public ICollection<Part> Parts { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
