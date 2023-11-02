using Api.DataBaseContext;
using Api.DTO.TagDTO;
using Api.Entity;
using Api.Services.Abstract;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Concrate
{
    public class TagService : ITagService
    {
        public readonly AppDbContext _context;
        public readonly IMapper _mapper;

        public TagService(AppDbContext context, IMapper mapper)
        {
                _context = context; 
                _mapper = mapper;
        }

 

        public async Task<CreateTagDTO> CreateTag(CreateTagDTO tag)
        {
           var map = _mapper.Map<CreateTagDTO , Tag>(tag);
            map.CreateDate = DateTime.Now;
            var addObj =await _context.Tags.AddAsync(map);
            var response =  _mapper.Map<Tag, CreateTagDTO>(addObj.Entity);

            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<bool> DeleteTag(int tagId)
        {
            var result =await _context.Blogs.FindAsync(tagId);

            if (result != null)
            {
               _context.Blogs.Remove(result);
                await _context.SaveChangesAsync();
            }

            return false;
        }

     

        public async Task<EditTagDTO> EditTag(EditTagDTO tag)
        {
            var result = await _context.Tags.FindAsync(tag.id);

            if (result != null)
            {
                var map = _mapper.Map<EditTagDTO, Tag>(tag);
                result.UpdateDate = DateTime.Now;
                result.Name = map.Name;

                //

                var response = _mapper.Map<Tag, EditTagDTO>(map);
                await _context.SaveChangesAsync();
                return response;

            }
            return null;
        }

        public async Task<List<Tag>> GetAllTags()
        {
            var result = await _context.Tags.ToListAsync();
            if (result != null) { 
            
                return result;
            }
            return null;
           
        }

        public async Task<Tag> GetTagById(int id)
        {
            var result =await _context.Tags.FindAsync(id);
            if (result != null)
            {

                return result;
            }
            return null;
           

        }
    }
}
