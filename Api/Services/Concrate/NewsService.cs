using Api.DataBaseContext;
using Api.DTO.NewsDTO;
using Api.DTO.ProductDTO;
using Api.Entity;
using Api.Services.Abstract;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Concrate
{
    public class NewsService : INewsService
    {
        public readonly AppDbContext _context;
        public readonly IMapper _mapper;

        public NewsService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<CreateNewsDTO> CreateNews(CreateNewsDTO news)
        {
            var map = _mapper.Map<CreateNewsDTO, News>(news);
            map.UpdateDate = DateTime.Now;
            map.CreateDate = DateTime.Now;
           ;
            var addedObj = await _context.News.AddAsync(map);

            var response = _mapper.Map<News, CreateNewsDTO>(addedObj.Entity);

            await _context.SaveChangesAsync();  
            return response;
        }

        public async Task<bool> DeleteNews(int id)
        {
            var result = await _context.News.FindAsync(id);
            if (result != null)
            {
                _context.News.Remove(result);
                await _context.SaveChangesAsync();
            }

           return false;
        }

        public async Task<EditNewsDTO> UpdateNews(EditNewsDTO news)
        {

            var result = await _context.News.FindAsync(news.Id);

            if (result != null)
            {
                var map = _mapper.Map<EditNewsDTO, News>(news);

                result.Name = map.Name;
                result.Description = map.Description;
                result.UpdateDate = DateTime.Now;
                result.Author = map.Author;
                result.CategoryId = map.CategoryId;

                var response = _mapper.Map<News, EditNewsDTO>(map);
                await _context.SaveChangesAsync();
                return response;
            }

            return null;
        }

        public async Task<List<News>> GetAllNews()
        {
            var result = await _context.News.ToListAsync();


            if (result !=null )
            {
                return result;
            }
            return null;
        }


        public async Task<News> GetNewsById(int id)
        {
            var result = await _context.News.FindAsync(id);


            if (result != null)
            {
                return result;
            }

            return null;
        }
    }
}
