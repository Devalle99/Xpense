using Xpense.application.Common;

namespace Xpense.application.Expenses.Models
{
    public class ExpenseReadDto : BaseDto
    {
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public int? CategoriaId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UsuarioId { get; set; }
    }
}
