﻿using Api.DataBaseContext;
using Api.DTO.BlogDTO;
using Api.Entity;
using Api.Services.Abstract;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
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

            //foreach (var item in blog.TagId)
            //{
            //    BlogTag blogTag = new BlogTag()
            //    {
            //        TagId = item,
            //        BlogId = blog.Id
            //    };

            //    _context.BlogTags.Add(blogTag);
            //    await _context.SaveChangesAsync();


            //}


            var response = _mapper.Map<Blog, CreateBlogDTO>(addObj.Entity);

            await _context.SaveChangesAsync();
            return response;


        }

        public async Task<bool> DeleteBlog(int blogId)
        {
            var result = await _context.Blogs.Include(
                x=> x.BlogTags).ThenInclude(bt=> bt.Tag).FirstOrDefaultAsync(x=> x.Id == blogId);

            if (result != null)
            {
               _context.Blogs.Remove(result);
               _context.BlogTags.RemoveRange(result.BlogTags);
                await _context.SaveChangesAsync();
            }
            return false;
        }

        public async Task<EditBlogDTO> EditBlog(EditBlogDTO blog)
        {
            var result = await _context.Blogs.Include(x=> x.BlogTags).ThenInclude(bt=> bt.Tag).FirstOrDefaultAsync(x=> x.Id == blog.Id);

            if (result != null)
            {
                var map = _mapper.Map<EditBlogDTO, Blog>(blog);
                map.UpdateDate = DateTime.Now;
                map.Name = blog.Name;
                map.Description = blog.Description;
                map.Author = blog.Author;
                //List<BlogTag> blogTags = new List<BlogTag>();

                //foreach (int tagId in blog.TagId)
                //{




                //    BlogTag blogTag = new BlogTag
                //    {
                //        CreateDate = DateTime.UtcNow.AddHours(+4),

                //        TagId = tagId

                //    };


                //    blogTags.Add(blogTag);
                //}

                



                
                map.CategoryId = blog.CategoryId;
               // map.BlogTags = blog.BlogTags;
                var response = _mapper.Map<Blog, EditBlogDTO>(map);

                await _context.SaveChangesAsync();
                return response;


            }

            return null;



        }

        public async Task<List<Blog>> GetAllBlogs()
        {
            var result= await _context.Blogs.Include(x=> x.BlogTags).ThenInclude(bt=> bt.Tag).ToListAsync();
            if (result != null)
            { 
                return result;
            }

            return null;
        }

        public async Task<Blog> GetBlogById(int id)
        {
            var result = await _context.Blogs.Include(x => x.BlogTags).ThenInclude(bt => bt.Tag).FirstOrDefaultAsync(x=> x.Id == id);

            if (result != null)
            {
                return result;
            }

            return null;
        }
    }
}
