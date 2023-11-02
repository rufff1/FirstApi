using Api.DTO.BlogDTO;
using Api.Entity;

namespace Api.Services.Abstract
{
    public interface IBlogServicecs
    {
        Task<CreateBlogDTO> CreateBlog(CreateBlogDTO blog);
        Task<EditBlogDTO> EditBlog(EditBlogDTO blog);
        Task<bool> DeleteBlog(int blogId);
        Task<List<Blog>> GetAllBlogs();
        Task<Blog> GetBlogById(int id);

    }
}
