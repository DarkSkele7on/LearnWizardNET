using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataLayer
{
    public class LearnWizardAppDbContext : IdentityDbContext<User>
    {
        public LearnWizardAppDbContext() : base()
        {

        }
        public LearnWizardAppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=LearnWizard;User=sa;Password=Zamunda06;Encrypt=True;TrustServerCertificate=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(c => c.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(c => c.Email).IsRequired();
            
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Course> Courses { get; set; }
    }
}
