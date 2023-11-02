using Api.DTO.TagDTO;
using Api.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        public readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
                _tagService = tagService;
        }


        [HttpPost("CreateTag")]
        public async Task<IActionResult> CreateTag(CreateTagDTO request)
        {
            var result = await _tagService.CreateTag(request);
            return Ok(result);
        }

        [HttpPost("UpdateTag")]
        public async Task<IActionResult> UpdateTag(EditTagDTO request)
        {
            var result = await _tagService.EditTag(request);
            return Ok(result);
        }
        [HttpDelete("DeleteTag")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var result =await _tagService.DeleteTag(id); 

            return Ok(result);
        }

        [HttpGet("GetAllTags")]
        public async Task<IActionResult> GetAllTags()
        {
            var response = await _tagService.GetAllTags();
            return Ok(response);
        }
        [HttpGet("GetUniqueTag")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var result = await (_tagService.GetTagById(id));
            return Ok(result);
        }
    }
}
