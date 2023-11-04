using Api.DTO.NewsDTO;
using Api.Entity;
using Api.Services.Abstract;
using Api.Services.Concrate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        public readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
                _newsService = newsService;
        }

        [HttpPost("CreateNews")]
        public async Task< IActionResult> CreateNews(CreateNewsDTO request) 
        {
          var result = await _newsService.CreateNews(request);
            if (result == null) return StatusCode(404, "yalnis melumat daxil edilib");

            
            return Ok(result);  
        
        }

        [HttpPost("EditNews")]
        public async Task<IActionResult> UpdateNews(EditNewsDTO request)
        {
            var result = await _newsService.UpdateNews(request);
            if (result == null) return StatusCode(404, "yalnis melumat daxil edilib");
            return Ok(result);
        }

        [HttpGet("GetUniqueNews")]
        public async Task<IActionResult> GetNewsById(int id)
        {
            var result = await _newsService.GetNewsById(id);
            if (result == null) return StatusCode(404, "yalnis melumat daxil edilib");
            return Ok(result);
        }

        [HttpGet("GetAllNews")]
        public async Task<IActionResult> GetAllNews()
        {
            var result = await _newsService.GetAllNews();

            if (result == null)
            {
                return StatusCode(404, "yalnis melumat");
            }

            return StatusCode(200, result);
        }

        [HttpDelete("DeleteNews")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            var result = await _newsService.DeleteNews(id);
            return Ok(result);  

        } 

    }
}
