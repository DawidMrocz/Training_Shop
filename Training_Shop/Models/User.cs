namespace Training_Shop.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public Address? Address { get; set; }
        public Cart Cart { get; set; } = null!;
    }
}
