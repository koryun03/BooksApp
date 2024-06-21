using BooksApp.Domain.Common.Constants;
using BooksApp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksApp.Infrastructure.EntityTypeConfigurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasData(
                new Role { Id = 1, Name = UserRoles.Admin, NormalizedName = UserRoles.Admin },
                new Role { Id = 2, Name = UserRoles.User, NormalizedName = UserRoles.User }
            );

        }
    }
}
