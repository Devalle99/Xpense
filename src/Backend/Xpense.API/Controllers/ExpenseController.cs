using Xpense.application.Expenses.Interfaces;
using Xpense.application.Expenses.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Xpense.domain.Expenses;

namespace Xpense.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ExpenseController : ControllerBase
    {

        private readonly ILogger<ExpenseController> _logger;
        private readonly IExpenseService _expenseService;
        public ExpenseController(ILogger<ExpenseController> logger, IExpenseService expenseService)
        {
            _logger = logger;
            _expenseService = expenseService;
        }

        /// <summary>
        /// www.test.com/api/expense/Create
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] ExpenseCreateDto expense)
        {
            try
            {
                var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;
                expense.UsuarioId = Guid.Parse(userId!);

                var createdExpense = await _expenseService.Create(expense);
                return StatusCode((int)HttpStatusCode.Created, createdExpense);
            }
            catch (Exception e)
            {
                _logger.LogError("ExpenseController error: Create " + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ExpenseReadDto expense)
        {
            try
            {
                var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;
                expense.UsuarioId = Guid.Parse(userId!);

                var updatedExpense = await _expenseService.Update(expense);
                return new OkObjectResult(updatedExpense);
            }
            catch (Exception e)
            {
                _logger.LogError("ExpenseController error: Update " + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
            // deberia comprobar que el Expense que se desea borrar corresponde al usuarioId actual
            // antes de permitir la eliminacion
        {
            try
            {
                var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;

                var isDeleted = await _expenseService.Delete(id, Guid.Parse(userId!));
                return new OkObjectResult(new { deleted = isDeleted });
            }
            catch (Exception e)
            {
                _logger.LogError("ExpenseController error: Delete " + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;

                var expense = await _expenseService.Get(id, Guid.Parse(userId!));

                return new OkObjectResult(expense);
            }
            catch (Exception e)
            {
                _logger.LogError("ExpenseController error: Get by Id " + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllForUser (
            [FromQuery] string orderBy = "fechaDesc",
            [FromQuery] int? categoryId = null,
            [FromQuery] decimal? minAmount = null,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            try
            {
                var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;

                var expenses = await _expenseService.GetAll(Guid.Parse(userId!), orderBy, categoryId, minAmount, startDate, endDate);

                return new OkObjectResult(expenses);
            }
            catch (Exception e)
            {
                _logger.LogError("ExpenseController error: Get All " + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }
        }        
        
        [HttpGet("GetTotals")]
        public async Task<IActionResult> GetTotals(
            [FromQuery] string attribute = "general",
            [FromQuery] int? categoryId = null,
            [FromQuery] DateTime? month = null)
        {
            try
            {
                var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;

                string expenses = await _expenseService.GetTotals(Guid.Parse(userId!), attribute, categoryId, month);

                return new OkObjectResult(expenses);
            }
            catch (Exception e)
            {
                _logger.LogError("ExpenseController error: Get Totals " + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }
        }

        [HttpGet("GetTotalsByCategory")]
        public async Task<IActionResult> GetTotalsByCategory(DateTime startDate, DateTime endDate)
        {
            try
            {
                var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;

                var jsonResult = await _expenseService.GetTotalsByCategory(Guid.Parse(userId!), startDate, endDate);
                return Ok(jsonResult);
            }
            catch (Exception e)
            {
                _logger.LogError("ExpenseController error: GetTotalsByCategory " + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }
        }
    }
}