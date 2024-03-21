using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskAribMVC.Models
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser, RoleEntity, string, IdentityUserClaim<string>, UserRoleEntity, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
               .ToTable("User", "Security");

            modelBuilder.Entity<RoleEntity>()
                .ToTable("Role", "Security");

            modelBuilder.Entity<UserRoleEntity>()
                .ToTable("UserRole", "Security");

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .ToTable("UserClaim", "Security");

            modelBuilder.Entity<IdentityRoleClaim<string>>()
                .ToTable("RoleClaim", "Security");

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .ToTable("UserLogin", "Security");

            modelBuilder.Entity<IdentityUserToken<string>>()
                .ToTable("UserToken", "Security");

          
            modelBuilder.ApplyConfiguration(new DefaultUsers());

        }
    }
}
