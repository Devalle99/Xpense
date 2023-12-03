using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xpense.application.Categories.Models;
using Xpense.application.Categories.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Xpense.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<IActionResult> Post([FromBody] CategoryCreateDto category)
        {
            List<CategoryCreateDto> categories = new List<CategoryCreateDto>();
            categories.Add(category);

            return StatusCode((int) HttpStatusCode.Created, categories);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get([FromQuery] string categoryId)
        {
            var categories = await _categoryService.GetAll();

            return new OkObjectResult(categories);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CategoryReadDto updatedCategory)
        {
            List<CategoryReadDto> categories = new List<CategoryReadDto>();
            categories.Add(updatedCategory);

            return new OkObjectResult(categories);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            List<CategoryReadDto> categories = new List<CategoryReadDto>();
            categories.Add(new CategoryReadDto
            {
                Id = 1,
                Usuario = 27,
                Nombre = "Educacion"
            });

            var deletedCategory = categories.FirstOrDefault(x=>x.Id == id);

            if (deletedCategory != null)
            {
                categories.Remove(deletedCategory);

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