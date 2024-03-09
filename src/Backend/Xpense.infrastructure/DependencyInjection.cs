using Xpense.infrastructure.Repositories.Categories.Interfaces;
using Xpense.infrastructure.Repositories.Categories;
using Xpense.infrastructure.Repositories.Expenses.Interfaces;
using Xpense.infrastructure.Repositories.Expenses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xpense.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Xpense.infrastructure.Repositories.Security.Interfaces;
using Xpense.infrastructure.Repositories.Security;

namespace Xpense.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<XpenseContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), providerOptions => providerOptions.EnableRetryOnFailure()));

            services.AddIdentityCore<IdentityUser<Guid>>()
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<XpenseContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IExpenseRepository, ExpenseRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            return services;
        }
    }
}
