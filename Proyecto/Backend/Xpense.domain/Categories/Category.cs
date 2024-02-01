using Microsoft.AspNetCore.Identity;
using Xpense.domain.Common;
using Xpense.domain.Expenses;

namespace Xpense.domain.Categories
{
    public class Category : BaseEntity
    {
        public string Nombre { get; set; }
        public ICollection<Expense>? Expenses { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
