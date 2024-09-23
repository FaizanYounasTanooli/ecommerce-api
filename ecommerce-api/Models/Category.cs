using ecommerce_api.Attributes;

namespace ecommerce_api.Models
{
    public class Category : BaseEntity
    {
        //I created my own attribute for Name (Just for fancy working)
        [Name]
        public string Name { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
