namespace Xpense.application.Expenses.Models
{
    public class ExpenseCreateDto
    {
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public int CategoriaId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
