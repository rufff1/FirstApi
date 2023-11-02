using Api.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entity
{
    public class Product :BaseEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        [Column(TypeName ="Decimal")]
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
