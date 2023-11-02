using Api.DataBaseContext;
using Api.DTO.CategoryDTO;
using Api.Entity;
using Api.Services.Abstract;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Concrate
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(AppDbContext context , IMapper mapper)
        {
                _mapper = mapper;   
                _context = context;
        }
        public async Task<CreateCategoryDTO> CreateCategory(CreateCategoryDTO category)
        {
            var map = _mapper.Map<CreateCategoryDTO, Category>(category);
            map.UpdateDate = DateTime.Now;
            map.CreateDate = DateTime.Now;
            var  addedObj =await _context.Categories.AddAsync(map);
            var response = _mapper.Map<Category, CreateCategoryDTO>(addedObj.Entity);

            await  _context.SaveChangesAsync(); 
            return response;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var result = await _context.Categories.FindAsync(id);

            if (result !=null)
            {
                  _context.Categories.Remove(result);
                await _context.SaveChangesAsync();
            }

            return false;
            

        }

        public async Task<List<Category>> GetAllCategories()
        {
            var result = await _context.Categories.ToListAsync();
            if (result != null)
            {
                return result;
            }

            return null;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var result =await _context.Categories.FirstOrDefaultAsync(x=> x.Id == id);
            if (result != null)
            {

                return result;
            }
            return null;
           
          
        }

        public async Task<EditCategoryDTO> UpdateCategory(EditCategoryDTO category)
        {
            var result = await _context.Categories.FindAsync(category.Id);

            if (result !=null)
            {
              var map   =    _mapper.Map<EditCategoryDTO, Category>(category);
                result.CategoryName = map.CategoryName;
                result.CategoryDescription = map.CategoryDescription;
                result.UpdateDate = DateTime.Now;
                result.CreateDate = DateTime.UtcNow;
                var response =     _mapper.Map<Category, EditCategoryDTO>(map);
                await _context.SaveChangesAsync();
                return response;
            }

            return null;
        }
    }
}
