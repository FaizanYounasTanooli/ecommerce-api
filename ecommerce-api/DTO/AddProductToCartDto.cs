namespace ecommerce_api.DTO
{
    public class AddProductToCartDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
