using Api.Entity;
using Api.Services.Concrate;
using Api.DTO.ProductDTO;

namespace Api.Services.Abstract
{
    public interface IProductService
    {
        Task<CreateProductDTO> CreateProduct(CreateProductDTO product);
        Task<EditProductDTO> UpdateProduct(EditProductDTO product);
        Task<bool> DeleteProduct(int id);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);


    }
}
