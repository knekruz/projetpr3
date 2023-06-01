using API_test3.Models;
using Microsoft.EntityFrameworkCore;

namespace API_test3.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cycle> Cycles { get; set; }
        public DbSet<Pointage> Pointages { get; set; }
        public DbSet<Calendrier> Calendriers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();

            modelBuilder.Entity<Admin>()
                .HasIndex(s => s.Username)
                .IsUnique();


            base.OnModelCreating(modelBuilder);
        }

    }
}
