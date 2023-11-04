using Api.Entity;

namespace Api.DTO.NewsDTO
{
    public class CreateNewsDTO
    {
   
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; } 
                                               

       
        public int CategoryId { get; set; } 
    }
}
