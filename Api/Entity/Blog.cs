using Api.Entity.Base;

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

    }
}
