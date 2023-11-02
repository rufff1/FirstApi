using Api.DataBaseContext;
using Api.DTO.BlogDTO;
using Api.Entity;
using Api.Services.Abstract;
using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Concrate
{
    public class BlogService : IBlogServicecs
    {
        public readonly AppDbContext _context;
        public readonly IMapper _mapper;

        public BlogService(AppDbContext context,IMapper mapper)
        {
                _context = context;
            _mapper = mapper;   
        }



        public async Task<CreateBlogDTO> CreateBlog(CreateBlogDTO blog)
        {
           var map = _mapper.Map<CreateBlogDTO , Blog>(blog);
            map.CreateDate = DateTime.Now;
            var addObj =  _context.Add(map);

            var response = _mapper.Map<Blog, CreateBlogDTO>(addObj.Entity);

            await _context.SaveChangesAsync();
            return response;


        }

        public async Task<bool> DeleteBlog(int blogId)
        {
            var result = await _context.Blogs.FindAsync(blogId);

            if (result != null)
            {
               _context.Blogs.Remove(result);
                await _context.SaveChangesAsync();
            }
            return false;
        }

        public async Task<EditBlogDTO> EditBlog(EditBlogDTO blog)
        {
            var result = await _context.Blogs.FindAsync(blog.Id);

            if (result != null)
            {
                var map = _mapper.Map<EditBlogDTO, Blog>(blog);
                map.UpdateDate = DateTime.Now;
                map.Name = blog.Name;
                map.Description = blog.Description;
                map.Author = blog.Author;
                map.CategoryId = blog.CategoryId;

                var response = _mapper.Map<Blog, EditBlogDTO>(map);

                await _context.SaveChangesAsync();
                return response;


            }

            return null;



        }

        public async Task<List<Blog>> GetAllCategories()
        {
            var result= await _context.Blogs.ToListAsync();
            if (result != null)
            {
                return result;
            }

            return null;
        }

        public async Task<Blog> GetBlogById(int id)
        {
            var result = await _context.Blogs.FirstOrDefaultAsync(x=> x.Id == id);

            if (result != null)
            {
                return result;
            }

            return null;
        }
    }
}
