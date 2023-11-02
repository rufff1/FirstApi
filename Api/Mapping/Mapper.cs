using Api.DTO.CategoryDTO;
using Api.DTO.ProductDTO;
using Api.DTO.BlogDTO;
using Api.DTO.TagDTO;

using Api.Entity;
using AutoMapper;

namespace Api.Mapping
{
    public class Mapper :Profile
    {
        public Mapper()
        {
            //CATEGORY MAPPING
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();  
            CreateMap<Category, EditCategoryDTO>().ReverseMap();
            
            //PRODUCT MAPPING
            CreateMap<Product , CreateProductDTO>().ReverseMap();
            CreateMap<Product , CreateProductDTO>().ReverseMap();

            //Blog Mapping
            CreateMap<Blog , CreateBlogDTO>().ReverseMap();
            CreateMap<Blog, EditBlogDTO>().ReverseMap();

            //Tag Mapping
            CreateMap<Tag, CreateTagDTO>().ReverseMap();
            CreateMap<Tag, EditBlogDTO>().ReverseMap();
          




        }
    }
}
