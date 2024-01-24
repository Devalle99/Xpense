using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpense.infrastructure.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Xpense.infraestructure.Seeders
{
    public class RoleSeeder : IEntityTypeConfiguration<IdentityRole<Guid>>
    {

        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(
                new IdentityRole<Guid>
                {
                    Id = Guid.Parse("b1f6c811-53a5-4819-bb47-28861c5f5a74"),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                },
                new IdentityRole<Guid>
                {
                    Id = Guid.Parse("21e56e0e-cf41-4602-a8ba-e38853c26954"),
                    Name = "User",
                    NormalizedName = "USER",
                }
            );
        }

    }
}
