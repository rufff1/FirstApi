using Api.DTO.TagDTO;
using Api.Entity;

namespace Api.Services.Abstract
{
    public interface ITagService
    {
        Task<CreateTagDTO> CreateTag(CreateTagDTO tag);
        Task<EditTagDTO> EditTag(EditTagDTO tag);
        Task<bool> DeleteTag(int id);
        Task<Tag> GetTagById(int id);
        Task<List<Tag>> GetAllTags();
    }
}
