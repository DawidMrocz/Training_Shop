using Training_Shop.Models;

namespace Training_Shop.Dto
{
    public class CartItemDto
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public bool? Available { get; set; }
    }
}
