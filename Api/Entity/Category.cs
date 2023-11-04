using Api.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Api.Entity
{
    public class Category :BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<Blog> Blogs { get; set;}
        public virtual List<News> News { get; set; }
    }
}
