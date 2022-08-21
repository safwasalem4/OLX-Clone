using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;


namespace Data.Configuration
{

    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            List<ApplicationUser> SeedUsers()
            {
                var users = new List<ApplicationUser>();
                var admin = new ApplicationUser
                {
                    Id = 1,
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "Admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FName = "Admin",
                    LName = "Admin",
                    PhoneNumber = "01234567891"
                };

                // generate user and user PW 
                PasswordHasher<ApplicationUser> ph = new();
                admin.PasswordHash = ph.HashPassword(admin, "string");
                users.Add(admin);
                
                for (int i = 1; i < 12; i++)
                {
                    var user = new ApplicationUser
                    {
                        Id= i + 1,
                        UserName = $"User{i}",
                        NormalizedUserName = $"USER{i}",
                        Email = "User@user.com",
                        NormalizedEmail = "USER@USER.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        FName = "User",
                        LName = $"{i}",
                        PhoneNumber = "01234567891"
                    };
                    // generate user and user PW 
                    user.PasswordHash = ph.HashPassword(user, "string");
                    users.Add(user);
                }
                return users;
            }
            builder.HasData(SeedUsers());
        }
    }
}

            
           
