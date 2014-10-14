using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Requirements_and_Design_environment.Models.Entities;
using System.Text;
using System.Reflection;

namespace Requirements_and_Design_environment.Infrastructure
{

    public partial class RdeDbContext : DbContext
    {
        public RdeDbContext()
            : base("name=RdeConnectionString")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Template> Templates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Project>()
            //    .Property(e => e.Visibility)
            //    .IsFixedLength();
        }
    }
}
