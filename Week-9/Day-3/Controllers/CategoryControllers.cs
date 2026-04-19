using Microsoft.AspNetCore.Mvc;
using CategoryService.Services;
using CategoryService.Models;

namespace CategoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            return Ok(await _service.Add(category));
        }
    }
}