using Xpense.application.Common;

namespace Xpense.application.Expenses.Models
{
    public class ExpenseGetAllDto : BaseDto
    {
        public string Concepto { get; set; }
        public string Monto { get; set; }
        public int? CategoriaId { get; set; }
        public string? CategoriaNombre { get; set; }
        public string CreatedAt { get; set; }
    }
}
