using Xpense.domain.Categories;
using Xpense.domain.Expenses;
using Xpense.infraestructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Xpense.infrastructure.Seeders;
using System.Reflection.Metadata;
using Microsoft.Extensions.Hosting;

namespace Xpense.infrastructure.Data
{
    public class XpenseContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }

        public XpenseContext(DbContextOptions<XpenseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Expense>()
                .Property(e => e.Monto)
                .HasColumnType("decimal(18, 2)"); // 18 es la precisión total y 2 es la escala (número de decimales)

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Expenses)
                .WithOne(e => e.Categoria)
                .HasForeignKey(e => e.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<Expense>()
            //    .HasOne(e => e.UsuarioId)
            //    .WithMany()
            //    .HasForeignKey(e => e.UsuarioId)
            //    .IsRequired();

            modelBuilder.ApplyConfiguration(new UserSeeder());
            modelBuilder.ApplyConfiguration(new RoleSeeder());
            modelBuilder.ApplyConfiguration(new UserRoleSeeder());
        }
    }
}
