namespace Training_Shop.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
        public bool Available { get; set; }
        public List<CartItem>? CartItems { get; set; }
    }
}
