using Ecom.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecom.Data
{
    public class EcommerceDataDbContext : DbContext
    {
        public EcommerceDataDbContext(DbContextOptions options) : base(options)
        {




        }
        public DbSet<Users> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(ur =>  new {ur.UserId,ur.RoleId});

            modelBuilder.Entity<UserRole>().HasOne(my => my.User).WithMany(u => u.UsersRole)

            .HasForeignKey(my => my.UserId);


            modelBuilder.Entity<UserRole>().HasOne(my => my.Role).WithMany(r => r.UsersRole)

            .HasForeignKey(my => my.RoleId);
        }
    }
}
