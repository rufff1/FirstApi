using Api.Entity.Base;



namespace Api.Entity
{
    public class Tag : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Blog> Blogs { get; set; }


    }
}
