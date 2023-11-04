using Api.DTO.CategoryDTO;
using Api.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (result == null)
            {
                return StatusCode(404, "yalnis melumat");
            }
            return Ok(result);
        }

        [HttpGet("GetUniqueCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _categoryService.GetCategoryById(id);
            if (result == null)
            {
                return StatusCode(404, "yalnis melumat");
            }
            return Ok(result);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
     
            
            return Ok(result);  

        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody]CreateCategoryDTO request)
        {
            var result = await _categoryService.CreateCategory(request);
            if (result == null)
            {
                return StatusCode(404, "yalnis melumat");
            }

            return StatusCode(201,result);

        }

        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody]EditCategoryDTO request)
        {
            var result = await _categoryService.UpdateCategory(request);
            if (result == null)
            {
                return StatusCode(404, "yalnis melumat");
            }
            

            
            return StatusCode(200,result);
        }

    }
}
