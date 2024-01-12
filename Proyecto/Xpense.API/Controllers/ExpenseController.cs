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
            try
            {
                var createdExpense = await _expenseService.Create(expense);
                return StatusCode((int)HttpStatusCode.Created, createdExpense);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ExpenseReadDto expense)
        {
            try
            {
                var updatedExpense = await _expenseService.Update(expense);
                return new OkObjectResult(updatedExpense);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var result = await _expenseService.Delete(id);
                return new OkObjectResult(new { deleted = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"Could not delete expense with id = {id}");
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var expenses = await _expenseService.GetAll();

                return new OkObjectResult(expenses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var expense = await _expenseService.Get(id);

                return new OkObjectResult(expense);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}