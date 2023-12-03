using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xpense.application.Expenses.Models;
using Xpense.application.Expenses.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Xpense.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : ControllerBase
    {
        
        private readonly ILogger<ExpenseController> _logger;
        private readonly IExpenseService _expenseService;

        public ExpenseController(ILogger<ExpenseController> logger, IExpenseService expenseService)
        {
            _logger = logger;
            _expenseService = expenseService;
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] ExpenseCreateDto expense)
        {
            List<ExpenseCreateDto> expenses = new List<ExpenseCreateDto>();
            expenses.Add(expense);

            return StatusCode((int) HttpStatusCode.Created, expenses);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get([FromQuery] string expenseId)
        {
            var expenses = await _expenseService.GetAll();

            return new OkObjectResult(expenses);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ExpenseReadDto updatedExpense)
        {
            List<ExpenseReadDto> expenses = new List<ExpenseReadDto>();
            expenses.Add(updatedExpense);

            return new OkObjectResult(expenses);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            List<ExpenseReadDto> expenses = new List<ExpenseReadDto>();
            expenses.Add(new ExpenseReadDto
            {
                Id = 1,
                Concepto = "Pago de matrícula UISEK",
                Monto = 1274.99M,
                CategoriaId = 5,
                Usuario = 27
            });

            var deletedExpense = expenses.FirstOrDefault(x=>x.Id == id);

            if (deletedExpense != null)
            {
                expenses.Remove(deletedExpense);

                // Devuelve un código de estado 204 No Content para indicar que se eliminó con éxito.
                return await Task.FromResult<IActionResult>(new NoContentResult());
            }
            else
            {
                return await Task.FromResult<IActionResult>(new NotFoundResult());
            }
        }
    }
}