using Api.DTO.NewsDTO;
using Api.Entity;

namespace Api.Services.Abstract
{
    public interface INewsService
    {
        Task<CreateNewsDTO> CreateNews(CreateNewsDTO news);
        Task<EditNewsDTO> UpdateNews(EditNewsDTO news);
        Task<bool> DeleteNews(int id);
        Task<News> GetNewsById(int id);
        Task<List<News>>GetAllNews();
    }
}
