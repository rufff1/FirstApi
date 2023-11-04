using Api.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Api.Entity
{
    public class News :BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;


        public int CategoryId {  get; set; }
        public virtual Category Category { get; set; }  

    }
}
