namespace Api.DTO.BlogDTO
{
    public class EditBlogDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }


        public int CategoryId { get; set; }
    }
}
