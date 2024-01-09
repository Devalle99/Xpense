using Xpense.application.Common;

namespace Xpense.application.Expenses.Models
{
    public class ExpenseReadDto : BaseDto
    {
        public int UsuarioId { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public int CategoriaId { get; set; }
    }
}
