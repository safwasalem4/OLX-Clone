using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;


namespace Data.Configuration
{
    public class UserRolesConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            List<ApplicationUserRole> userRoles = new();
            userRoles.Add(new ApplicationUserRole() { RoleId = 1, UserId = 1 });
            for (int i = 1; i < 12; i++)
            {
                userRoles.Add(new ApplicationUserRole() { RoleId = 2, UserId = i + 1 });
            }
            builder.HasData(userRoles);
        }
    }
}
