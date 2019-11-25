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
            set.ReleaseYear = 2019;
            set.Theme = "Technic";
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
                Color = "Dark Bluish Gray",
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
                Color = "Black",
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

            Set setTruck = new Set();
            setTruck.Age = 11;
            setTruck.Dimensions = new Dimensions()
            {
                Length = 65.2,
                Width = 9.6,
                Height = 43.2
            };
            setTruck.Images = new List<Image>()
            {
                new Image()
                {
                    ImageUrl="https://firebasestorage.googleapis.com/v0/b/legocompanion.appspot.com/o/Technic%2F8285.png?alt=media&token=3904df4b-fb32-4aa7-a3da-c7376143effb"
                },
                new Image()
                {
                    ImageUrl="https://firebasestorage.googleapis.com/v0/b/legocompanion.appspot.com/o/Technic%2F8285Box.jpg?alt=media&token=eafcf6a3-8fb2-4ed5-96f2-6e68e329c1c9"
                }
            };
            setTruck.Price = 119.99;
            setTruck.ReleaseYear = 2005;
            setTruck.Theme = "Technic";
            setTruck.SetName = "Tow Truck";
            setTruck.Pieces = 1877;
            setTruck.LegoCode = 8285;


            Part part3 = new Part()
            {
                PartName = "Pneumatic Pump Second Version with Black Top",
                Color = "Yellow",
                Images = new List<Image>()
                {
                    new Image() {
                        ImageUrl = "https://firebasestorage.googleapis.com/v0/b/legocompanion.appspot.com/o/Parts%2F74720.png?alt=media&token=f2cfcd2f-bf4b-4184-af69-0f611336a13a"
                    }
                },
                LegoCode = 74720,
                Price = 1.2
            };


            Part part4 = new Part()
            {
                PartName = "Technic Hook Large Metal",
                Color = "Black",
                Images = new List<Image>()
                {
                    new Image() {
                        ImageUrl = "https://firebasestorage.googleapis.com/v0/b/legocompanion.appspot.com/o/Parts%2F70644.jpg?alt=media&token=4e7498b8-afed-4cf5-bdcd-8398b10ce4b5"
                    }
                },
                LegoCode = 70644,
                Price = 7.03
            };

            setTruck.SetParts = new List<SetPart>();

            SetPart setPart3 = new SetPart()
            {
                Set = setTruck,
                Part = part3,
                Amount = 15
            };
            SetPart setPart4 = new SetPart()
            {
                Set = setTruck,
                Part = part4,
                Amount = 2
            };

            setTruck.SetParts.Add(setPart3);
            setTruck.SetParts.Add(setPart4);

            context.Sets.Add(setTruck);

            Set setBulldozer = new Set();
            setBulldozer.Age = 11;
            setBulldozer.Dimensions = new Dimensions()
            {
                Length = 65.2,
                Width = 9.6,
                Height = 43.2
            };
            setBulldozer.Images = new List<Image>()
            {
                new Image()
                {
                    ImageUrl="https://firebasestorage.googleapis.com/v0/b/legocompanion.appspot.com/o/Technic%2F8275.jpg?alt=media&token=eeb6bb98-3dd0-4e73-b7b4-7f1ebb097b56"
                },
                new Image()
                {
                    ImageUrl="https://firebasestorage.googleapis.com/v0/b/legocompanion.appspot.com/o/Technic%2F8275Box.jpg?alt=media&token=22742e39-99fc-47d7-98dd-1b9b563862da"
                }
            };
            setBulldozer.Price = 154.99;
            setBulldozer.ReleaseYear = 2007;
            setBulldozer.Theme = "Technic";
            setBulldozer.SetName = "Motorized Bulldozer";
            setBulldozer.Pieces = 1384;
            setBulldozer.LegoCode = 8275;

            setBulldozer.SetParts = new List<SetPart>();

            Part part5 = new Part()
            {
                PartName = "M Cross Axle W. Groove",
                Color = "Red",
                Images = new List<Image>()
                {
                    new Image() {
                        ImageUrl = "https://firebasestorage.googleapis.com/v0/b/legocompanion.appspot.com/o/Parts%2F4142865.jpg?alt=media&token=7530c93f-dd6e-4689-a0e5-00e7b410cd0a"
                    }
                },
                LegoCode = 4142865,
                Price = 0.06
            };


            Part part6 = new Part()
            {
                PartName = "Electric, Power Functions Receiver Unit",
                Color = "Dark Bluish Gray",
                Images = new List<Image>()
                {
                    new Image() {
                        ImageUrl = "https://firebasestorage.googleapis.com/v0/b/legocompanion.appspot.com/o/Parts%2F4506085.png?alt=media&token=6be8ae2d-d4ca-4ba9-9745-dee80509696a"
                    }
                },
                LegoCode = 4506085,
                Price = 10.23
            };

            SetPart setPart5 = new SetPart()
            {
                Set = setBulldozer,
                Part = part5,
                Amount = 15
            };
            SetPart setPart6 = new SetPart()
            {
                Set = setBulldozer,
                Part = part6,
                Amount = 2
            };

            setBulldozer.SetParts.Add(setPart5);
            setBulldozer.SetParts.Add(setPart6);

            context.Sets.Add(setBulldozer);

            User user = new User();
            user.GoogleID = "114370788929343747562";
            user.Email = "jeffvandenbroeck99@gmail.com";
            user.WishlistSets = new List<Set>()
            {

                setBulldozer

            };

            context.Users.Add(user);

            context.SaveChanges();
        }
    }
}
