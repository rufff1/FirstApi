using Api.DataBaseContext;
using Api.DTO.BlogDTO;
using Api.Entity;
using Api.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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

                return StatusCode(201,result);
            }
            catch (Exception ex)
            {

               

               
                return StatusCode(404, $"{ex.Message}");
            }

       

           
        }

        [HttpPost("UpdateBlog")]
       public async Task<IActionResult> EditBlog(EditBlogDTO requst)
        {



            var result = await _blogServicecs.EditBlog(requst);

            if (result == null)
            {
                return StatusCode(404, "Yalnis melumat");
            }
            else
            {

               return Ok(result);
            }



        }

        [HttpGet("GetAllBlogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var result = await _blogServicecs.GetAllBlogs();

            if (result == null) return StatusCode(200, "Emeliyyat ugurlu");

            return Ok(result);
        }

        [HttpGet("GetUniqueBlog")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            try
            {
                var result = await _blogServicecs.GetBlogById(id);
                return StatusCode(200,result);

            }
            
            catch (Exception ex)
            {
              
                  return StatusCode(404, $"Bu Id yalnisdir {ex.Message}");
            }

           
        }

        [HttpDelete("DeleteBlog")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
                var result = await _blogServicecs.DeleteBlog(id);
            try
            {
                return StatusCode(200, "Blog Ugurla Silindi");
            }
            catch (Exception ex)
            {
                   return StatusCode(404, $"{ex.Message}Yalnis melumat");

            }
            return null;
        }
    }

}
