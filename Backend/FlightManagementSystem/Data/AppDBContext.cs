using FlightManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementSystem.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext (DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "demouser",
                    Email = "demouser@gmail.com",
                    MobileToken = "token1",
                    CreatedOn = DateTime.UtcNow
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "Hiren Andharia",
                    Email = "hirenandharia@yopmail.com",
                    MobileToken = "token2",
                    CreatedOn = DateTime.UtcNow
                }
            );
        }
    } 
}