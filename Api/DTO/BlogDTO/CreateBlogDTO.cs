﻿namespace Api.DTO.BlogDTO
{
    public class CreateBlogDTO
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }


        public int CategoryId { get; set; }
    }
}
