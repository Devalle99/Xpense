using Xpense.domain.Common;

namespace Xpense.domain.Expenses
{
    public class Expense : AuditEntity
    {
        public required int Usuario { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public int CategoriaId { get; set; }
    }
}
