namespace ecommerce_api.DTO
{
    public class AddProductDto : BaseDto
    {
        public string Name { get; set; }
        public int OpeningQty { get; set; }
        public int Qty { get; set; }

    }
}
