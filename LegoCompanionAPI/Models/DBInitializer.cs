using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoCompanionAPI.Models
{
    public class DBInitializer
    {
        public static void Initialize(LegoContext context)
        {
            context.Database.EnsureCreated();

            if(context.Parts.Any())
            { 
                return; 
            }

            context.Parts.AddRange(
                new Part { PartName = "Red Brick", Color = Color.Blue, LegoCode = 10, Price = 0.15 }
                );

            context.SaveChanges();
        }
    }
}
