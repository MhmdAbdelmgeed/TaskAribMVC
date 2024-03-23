using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskAribMVC.Models
{
    public class DefaultUsers : IEntityTypeConfiguration<ApplicationUser>
    {

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var administrator = new ApplicationUser()
            {
                Id = "6bf1ea57-1d07-4e8f-97d4-2b3c050a979f",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "Admin@yahoo.com",
                NormalizedEmail = "ADMIN@YAHOO.COM",
                EmailConfirmed = true,
                PhoneNumber = "01091715735",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            var hasher = new PasswordHasher<ApplicationUser>();
            administrator.PasswordHash = hasher.HashPassword(administrator, "Password1!");
            builder.HasData(administrator);
        }
    }

}
