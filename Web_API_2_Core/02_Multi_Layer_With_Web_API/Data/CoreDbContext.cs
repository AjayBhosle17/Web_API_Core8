using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Email = "admin@gmail.com", Password = "ab1718" },
                new User() { Id = 2, Email = "user@gmail.com", Password = "ab1718" }
            );
           
            modelBuilder.Entity<Role>().HasData(
               new Role() { Id = 1,Name = "admin"},
               new Role() { Id = 2,Name="user" }
           );

            modelBuilder.Entity<UserRole>().HasData(
               new UserRole() { Id = 1, UserId=1 , RoleId= 1 },
               new UserRole() { Id = 2, UserId = 2, RoleId = 2 }
           );
        }

    }
}
