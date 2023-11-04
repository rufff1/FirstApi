using Api.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Api.Entity
{
    public class BlogTag :BaseEntity
    {
        [Key]

        public int Id { get; set; }

        public int TagId {  get; set; }
        public Tag  Tag { get; set; }


        public int BlogId {get; set; }
        public Blog Blog { get; set; }
    }
}
