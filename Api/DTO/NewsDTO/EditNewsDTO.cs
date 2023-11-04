namespace Api.DTO.NewsDTO
{
    public class EditNewsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;


        public int CategoryId { get; set; }
    }
}
