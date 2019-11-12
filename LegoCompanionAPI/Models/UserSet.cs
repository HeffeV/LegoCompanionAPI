using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoCompanionAPI.Models
{
    public class UserSet
    {
        public long UserSetID { get; set; }
        public long? SetID { get; set; }
        public long? UserID { get; set; }
        public Set Set { get; set; }
        public User User { get; set; }
        public int Amount { get; set; }
    }
}
