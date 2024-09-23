using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_api.Models
{
    public class Cart : BaseEntity
    {

        
        public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
