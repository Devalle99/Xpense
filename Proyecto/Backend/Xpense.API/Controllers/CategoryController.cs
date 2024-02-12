using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xpense.application.Categories.Models;
using Xpense.application.Categories.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using Xpense.domain.Categories;

namespace Xpense.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }


        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryCreateDto category)
        {
            try
            {
                var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;
                category.UsuarioId = Guid.Parse(userId!);

                var categoryResult = await _categoryService.Create(category);
                return StatusCode((int)HttpStatusCode.Created, categoryResult);
            }
            catch (Exception e)
            {
                _logger.LogError("CategoryController error: CreateAsync " + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CategoryReadDto category)
        {
            try
            {
                var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;
                category.UsuarioId = Guid.Parse(userId!);

                var categoryResult = await _categoryService.Update(category);
                return new OkObjectResult(categoryResult);
            }
            catch (Exception e)
            {
                _logger.LogError("CategoryController error: Update " + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var result = await _categoryService.Delete(id);

                return new OkObjectResult(new { deleted = result });
            }
            catch (Exception e)
            {
                _logger.LogError("CategoryController error: Delete " + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;

                var category = await _categoryService.Get(Guid.Parse(userId!), id);

                return new OkObjectResult(category);
            }
            catch (InvalidOperationException e)
            {
                _logger.LogInformation($"Category with id {id} not found " + e.Message);
                return NotFound($"Category with id {id} not found");
            }
            catch (Exception e)
            {
                _logger.LogError("CategoryController error: GetById " + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;

                var categories = await _categoryService.GetAll(Guid.Parse(userId!));

                return new OkObjectResult(categories);
            }
            catch (Exception e)
            {
                _logger.LogError("CategoryController error: GetAll " + e.Message);
                return BadRequest("Bad Request, contact administrator");
            }
        }
    }
}