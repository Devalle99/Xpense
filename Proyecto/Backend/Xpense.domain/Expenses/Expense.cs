using Xpense.domain.Common;
using Xpense.domain.Categories;
using System.Security.Principal;
using Microsoft.IdentityFramework;

namespace Xpense.domain.Expenses
{
    public class Expense : AuditEntity
    {
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public int? CategoriaId { get; set; }
        public Category? Categoria { get; set; }
        public Guid UsuarioId { get; set; }
        public IdentityUser Usuario { get; set; }
     }
}
