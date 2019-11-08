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

            Set set = new Set();
            set.Age = 12;
            set.Pieces = 4108;
            set.LegoCode = 42100;
            set.SetName = "Liebherr R 9800 Excavator";
            set.Price = 449.99;
            set.ReleaseDate = new DateTime(2019, 08, 01);
            set.Theme = Theme.Technic;
            set.Dimensions = new Dimensions()
            {
                Length = 65,
                Width = 27,
                Height = 39
            };
            set.Images = new List<Image>()
            {
                new Image(){
                    ImageUrl= "https://firebasestorage.googleapis.com/v0/b/legocompanion.appspot.com/o/Technic%2FLiebherr.jpg?alt=media&token=cd2f8dde-1438-4c68-ac63-ed20333ee748"
                },
                new Image(){
                    ImageUrl="https://firebasestorage.googleapis.com/v0/b/legocompanion.appspot.com/o/Technic%2FLiebherrbox.jpg?alt=media&token=79a8b10b-c3f3-47be-bd1d-63b520429aa2"
                }
            };

            Part part1 = new Part()
            {
                PartName = "Technic Digger Bucket 10 x 19",
                Color = Color.DarkBluishGray,
                Dimensions = new Dimensions()
                {
                    Length = 12,
                    Width = 19,
                    Height = 12
                },
                Images = new List<Image>()
                {
                    new Image() {
                        ImageUrl = "https://firebasestorage.googleapis.com/v0/b/legocompanion.appspot.com/o/Technic%2FShovel_46891.jpg?alt=media&token=b2f84b2b-f89f-4b64-af35-a4b3dc382042"
                    }
                },
                LegoCode = 46891,
                Price = 0
            };

            Part part2 = new Part()
            {
                PartName = "Plate 1 x 2",
                Color = Color.Black,
                Dimensions = new Dimensions()
                {
                    Length = 0.8,
                    Width = 1.6,
                    Height = 0.5
                },
                Images = new List<Image>()
                {
                    new Image() {
                        ImageUrl = "https://firebasestorage.googleapis.com/v0/b/legocompanion.appspot.com/o/Technic%2Flego-plate-1x2.jpg?alt=media&token=1f726aae-fe72-4c4a-898f-27ab6b842b03"
                    }
                },
                LegoCode = 3023,
                Price = 0.05
            };

            set.SetParts = new List<SetPart>();

            SetPart setPart1 = new SetPart()
            {
                Set = set,
                Part = part1,
                Amount = 1
            };
            SetPart setPart2 = new SetPart()
            {
                Set = set,
                Part = part2,
                Amount=2
            };

            set.SetParts.Add(setPart1);
            set.SetParts.Add(setPart2);

            context.Sets.Add(set);

            context.SaveChanges();
        }
    }
}
