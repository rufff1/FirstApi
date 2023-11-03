using Api.Entity;

namespace Api.DTO.BlogDTO
{
    public class CreateBlogDTO
    {
       // public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }


        public int CategoryId { get; set; }
        public List<int> TagId { get; set; }
       // public List<BlogTag> BlogTags { get; set; } 
    }
}
