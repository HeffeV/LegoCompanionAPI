using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoCompanionAPI.Models
{
    public class LegoContext:DbContext
    {
        public LegoContext(DbContextOptions<LegoContext> options) : base(options) 
        { }
        public DbSet<Part> Parts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            modelBuilder.Entity<Part>().ToTable("Part"); 
        }
    }
}
