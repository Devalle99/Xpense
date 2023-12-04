using Xpense.domain.Categories;
using Xpense.domain.Expenses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpense.infrastructure.Data
{
    public class XpenseContext : DbContext
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
        }
    }
}
