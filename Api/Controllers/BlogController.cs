using Api.DTO.BlogDTO;
using Api.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public readonly IBlogServicecs _blogServicecs;

        public BlogController(IBlogServicecs blogServicecs)
        {
            _blogServicecs = blogServicecs;
        }


        [HttpPost("CreateBlog")]
        public async Task<IActionResult> CreateBlog(CreateBlogDTO request)
        {

            try
            {
                var result = await _blogServicecs.CreateBlog(request);

                return Ok(result);
            }
            catch (Exception ex)
            {

               

               
                return StatusCode(500, $"{ex.Message}");
            }

       

           
        }

        [HttpPost("UpdateBlog")]
       public async Task<IActionResult> EditBlog(EditBlogDTO requst)
        {



            var result = await _blogServicecs.EditBlog(requst);

            return Ok(result);


        }

        [HttpGet("GetAllBlogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var result = await _blogServicecs.GetAllCategories();
            return Ok(result);
        }

        [HttpGet("GetUniqueBlog")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            try
            {
                var result = await _blogServicecs.GetBlogById(id);
                return Ok(result);

            }
            
            catch (Exception ex)
            {
             
                  return StatusCode(500, $"Bu Id yalnisdir {ex.Message}");
            }

           
        }

        [HttpDelete("DeleteBlog")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var result = await _blogServicecs.DeleteBlog(id);
            return Ok(result);
        }
    }

}
