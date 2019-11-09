using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegoCompanionAPI.Models;

namespace LegoCompanionAPI.Models
{
    public class LegoContext:DbContext
    {
        public LegoContext(DbContextOptions<LegoContext> options) : base(options) 
        { }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Dimensions> Dimensions { get; set; }
        public DbSet<SetPart> SetParts { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            modelBuilder.Entity<Part>().ToTable("Part");
            modelBuilder.Entity<Set>().ToTable("Set");
            modelBuilder.Entity<Image>().ToTable("Image");
            modelBuilder.Entity<Dimensions>().ToTable("Dimensions");
            modelBuilder.Entity<SetPart>().ToTable("SetPart");
            modelBuilder.Entity<User>().ToTable("User");
        }
        public DbSet<LegoCompanionAPI.Models.User> User { get; set; }
    }
}
