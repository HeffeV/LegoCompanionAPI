using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LegoCompanionAPI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string GoogleID { get; set; }
        public string Email { get; set; }

        public ICollection<Part> FavoriteParts { get; set; }
        public ICollection<Part> WishlistParts { get; set; }
        public ICollection<Set> FavoriteSets { get; set; }
        public ICollection<Set> WishlistSets { get; set; }
        public ICollection<Part> CollectionParts { get; set; }
        public ICollection<Set> CollectionSets { get; set; }
    }
}
