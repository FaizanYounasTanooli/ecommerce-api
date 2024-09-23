using ecommerce_api.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_api.Models
{
    public class Product : BaseEntity
    {
        [Name]
        public string Name { get; set; } = null!;
        [ForeignKey("categoryId")]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }


    }
}
