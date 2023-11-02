using Api.DTO.CategoryDTO;
using Api.Entity;

namespace Api.Services.Abstract
{
    public interface ICategoryService
    {
        Task<CreateCategoryDTO> CreateCategory(CreateCategoryDTO category);
        Task<EditCategoryDTO> UpdateCategory(EditCategoryDTO category);
        Task<bool> DeleteCategory(int id);
        Task<List<Category>> GetAllCategories();
      
        Task<Category> GetCategoryById(int id);

    }
}
