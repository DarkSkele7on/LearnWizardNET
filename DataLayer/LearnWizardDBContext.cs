using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataLayer
{
    public class LearnWizardDBContext : IdentityDbContext<User>
    {
        public LearnWizardDBContext() : base() { }

        public LearnWizardDBContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=LearnWizard;Trusted_Connection=True;Encrypt=False");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Admin",
                    Email = "adminadminov@abv.bg"
                });
            base.OnModelCreating(modelBuilder);
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }
    }
}
