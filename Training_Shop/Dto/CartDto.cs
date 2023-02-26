using Training_Shop.Models;

namespace Training_Shop.Dto
{
    public class CartDto
    {
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string? Name { get; set; }
        public List<CartItemDto>? CartItems { get; set; }
    }
}
