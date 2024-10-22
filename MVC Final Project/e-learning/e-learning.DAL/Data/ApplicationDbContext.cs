using e_learning.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace e_learning.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = Guid.NewGuid().ToString();
            var superAdminRoleId = Guid.NewGuid().ToString();
            var UserRoleId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole{ Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN"},
                 new IdentityRole { Id = superAdminRoleId, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                  new IdentityRole { Id = UserRoleId, Name = "User", NormalizedName = "USER" }
                );

            var hasher = new PasswordHasher<ApplicationUser>();
           
            var adminUser=new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
            UserName = "Admin@comp.com",
                NormalizedUserName = "ADMIN@COMP.COM",
                Email = "Admin@comp.com",
                NormalizedEmail = "ADMIN@COMP.COM",
                EmailConfirmed = true
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@12345");
          
            var superAdminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
            UserName = "SuperAdmin@comp.com",
                NormalizedUserName = "SUPERADMIN@COMP.COM",
                Email = "SUPERADMIN@comp.com",
                NormalizedEmail = "SUPERADMIN@COMP.COM",
                EmailConfirmed = true
            };

            superAdminUser.PasswordHash = hasher.HashPassword(superAdminUser, "SuperAdmin@12345");
           
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
            UserName = "User@comp.com",
                NormalizedUserName = "USER@COMP.COM",
                Email = "USER@comp.com",
                NormalizedEmail = "USER@COMP.COM",
                EmailConfirmed = true
            };

            user.PasswordHash = hasher.HashPassword(user, "User@12345");

            builder.Entity<ApplicationUser>().HasData(adminUser, superAdminUser, user);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = adminRoleId, UserId = adminUser.Id },
                new IdentityUserRole<string> { RoleId = superAdminRoleId, UserId = superAdminUser.Id },
                new IdentityUserRole<string> { RoleId = UserRoleId, UserId = user.Id }
                );
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
    }
}