using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_api.Models
{
    public class CartItem : BaseEntity
    {
        [ForeignKey("productId")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("cartId")]
        public string CartId { get; set; }
        public virtual Cart Cart { get; set; }

    }
}
