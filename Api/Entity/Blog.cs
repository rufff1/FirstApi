using Api.Entity.Base;
using Api.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Entity
{
    public class Blog : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

      
        public int CategoryId {  get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Tag> Tags {  get; set; } 



    }


}
