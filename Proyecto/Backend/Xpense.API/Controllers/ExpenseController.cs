using Xpense.application.Expenses.Interfaces;
using Xpense.application.Expenses.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

        private Guid ObtenerUserIdActual()
        {
            var tokenFromCookie = HttpContext.Request.Cookies["token"];

            if (string.IsNullOrEmpty(tokenFromCookie))
            {
                // El token está ausente o es inválido, puedes manejarlo según tus necesidades
                throw new InvalidOperationException("Token no presente o inválido");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var jsonToken = tokenHandler.ReadToken(tokenFromCookie) as JwtSecurityToken;

            if (jsonToken != null)
            {
                var userIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid);

                if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out var userId))
                {
                    // Devuelve el ID del usuario si se pudo parsear correctamente
                    return userId;
                }
            }

            // Si algo sale mal, puedes lanzar una excepción o devolver un valor predeterminado según tus necesidades
            throw new InvalidOperationException("No se pudo obtener el ID del usuario desde el token");
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
                // sobreescribir el id del usuario que lo esta creando
                expense.UsuarioId = ObtenerUserIdActual();

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
                // Obtener el Guid del usuario que desea editar
                Guid UsuarioId = ObtenerUserIdActual();

                var updatedExpense = await _expenseService.Update(expense, UsuarioId);
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
                return BadRequest($"Could not delete expense with {id}");
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
        
        [HttpGet("GetAllForUser")]
        public async Task<IActionResult> GetAllForUser([FromBody] string sort = "alfabetico", [FromBody] string filter = "ninguno")
        {
            try
            {
                var expenses = await _expenseService.GetAllForUser(sort, filter);

                return new OkObjectResult(expenses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
        
        [HttpGet("GetTotalsForUser")]
        public async Task<IActionResult> GetTotalsForUser([FromBody] string attribute = "general")
        {
            try
            {
                var expenses = await _expenseService.GetTotalsForUser(attribute);

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
                // Obtener el GUID del usuario autenticado (puedes obtenerlo según tu sistema de autenticación)
                Guid userId = ObtenerUserIdActual();

                var expense = await _expenseService.Get(id, userId);

                return new OkObjectResult(expense);
            }
            catch (InvalidOperationException ex)
            {
                // Manejar la excepción específica que indica que el gasto no existe o no pertenece al usuario actual
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones
                return BadRequest(ex.Message);
            }
        }

    }
}