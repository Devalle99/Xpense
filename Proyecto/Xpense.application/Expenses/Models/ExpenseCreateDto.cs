namespace Xpense.application.Expenses.Models
{
    public class ExpenseCreateDto
    {
        public int Usuario { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public int CategoriaId { get; set; }
    }
}
