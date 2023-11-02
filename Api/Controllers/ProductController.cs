using Api.DTO.ProductDTO;
using Api.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
                _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllProducts();

            return Ok(result);  
        }

        [HttpGet("GetUniqueProduct")]
        public async Task< IActionResult> GetProduct(int id)
        {
            var result = await _productService.GetProductById(id);
            return Ok(result);

        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            return Ok(result);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDTO request)
        {
            var result  = await _productService.CreateProduct(request);

            return Ok(result);
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(EditProductDTO request)
        {
            var result = await _productService.UpdateProduct(request);

            return Ok(result);
        }
    }
}
