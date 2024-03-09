using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Xpense.infraestructure.Seeders
{
    public class UserSeeder : IEntityTypeConfiguration<IdentityUser<Guid>>
    {

        public void Configure(EntityTypeBuilder<IdentityUser<Guid>> builder)
        {
            var hasher = new PasswordHasher<IdentityUser<Guid>>();

            builder.HasData(
                new IdentityUser<Guid>
                {
                    Id = Guid.Parse("4406ace7-f597-46b1-8d16-e828d724e8bd"),
                    UserName = "admin@example.com",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Ecuador2024!"),
                    SecurityStamp = "WSC5KCXECFWP474KDDZNQOVKVZIRBGBS",
                    ConcurrencyStamp = "8f544974-8cdb-4865-b876-e6f632b78547",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                
                new IdentityUser<Guid>
                {
                    Id = Guid.Parse("398791a8-38c0-46d5-875c-aecbe3636ff6"),
                    UserName = "user@example.com",
                    NormalizedUserName = "USER@EXAMPLE.COM",
                    Email = "user@example.com",
                    NormalizedEmail = "USER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Ecuador2024!"),
                    SecurityStamp = "DDZNQOVKVZIRBGBSWSC5KCXECFWP474KDDZNQOVKVZIRBGBS",
                    ConcurrencyStamp = "b876-e6f632b78547-8f544974-8cdb-4865-b876-e6f632b78547",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                }
            );
        }

    }
}
