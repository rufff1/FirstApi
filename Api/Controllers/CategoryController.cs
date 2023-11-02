using Api.DTO.CategoryDTO;
using Api.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
                _categoryService = categoryService;
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryService.GetAllCategories();

            return Ok(result);
        }

        [HttpGet("GetUniqueCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _categoryService.GetCategoryById(id);

            return Ok(result);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategory(id);

            return Ok(result);  

        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO request)
        {
            var result = await _categoryService.CreateCategory(request);
            return Ok(result);

        }

        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(EditCategoryDTO request)
        {
            var result = await _categoryService.UpdateCategory(request);
            return Ok(result);
        }

    }
}
