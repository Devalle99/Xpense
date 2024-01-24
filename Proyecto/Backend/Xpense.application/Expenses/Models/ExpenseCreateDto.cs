namespace Xpense.application.Expenses.Models
{
    public class ExpenseCreateDto
    {
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public int CategoryId { get; set; }
    }
}
