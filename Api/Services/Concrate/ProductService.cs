using Api.DataBaseContext;
using Api.DTO.CategoryDTO;
using Api.DTO.ProductDTO;
using Api.Entity;
using Api.Services.Abstract;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Concrate
{
    public class ProductService : IProductService
    {
        public readonly AppDbContext _context;
        public readonly IMapper _mapper;

        public ProductService(AppDbContext context, IMapper mapper)
        {
                _context = context;
            _mapper = mapper;
        }



        public async Task<CreateProductDTO> CreateProduct(CreateProductDTO product)
        {
            var map = _mapper.Map<CreateProductDTO, Product>(product);
            map.UpdateDate = DateTime.Now;
            map.CreateDate = DateTime.Now;
            var addedObj = _context.Products.Add(map);
            var response = _mapper.Map<Product, CreateProductDTO>(addedObj.Entity);

            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var result = await _context.Products.FindAsync(id);

            if (result != null)
            {
                _context.Products.Remove(result);
                await _context.SaveChangesAsync();
            }

            return false;

        }

        public async Task<List<Product>> GetAllProducts()
        {
            var result = await _context.Products.ToListAsync();

            if (result != null)
            {
                return result;
            }

            return null;
        }

        public async Task<Product> GetProductById(int id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

         
                return result;
            

           
        }

        public async Task<EditProductDTO> UpdateProduct(EditProductDTO product)
        {
            var result = await  _context.Products.FindAsync(product.Id);
            if (result != null)
            {
                var map = _mapper.Map<EditProductDTO, Product>(product);
                result.ProductName = map.ProductName;
                result.ProductDescription = map.ProductDescription;
                result.UpdateDate = DateTime.Now;
                result.ProductPrice = map.ProductPrice;
                result.CategoryId = map.CategoryId;
                
                var response = _mapper.Map<Product, EditProductDTO>(map);
                await _context.SaveChangesAsync();
                return response;
            }

            return null;


        }
    }
}
