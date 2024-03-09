using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpense.infrastructure.Seeders
{
    public class UserRoleSeeder : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("b1f6c811-53a5-4819-bb47-28861c5f5a74"),
                    UserId = Guid.Parse("4406ace7-f597-46b1-8d16-e828d724e8bd"),
                },
                
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("21e56e0e-cf41-4602-a8ba-e38853c26954"),
                    UserId = Guid.Parse("398791a8-38c0-46d5-875c-aecbe3636ff6"),
                }
                );
        }

    }
}
