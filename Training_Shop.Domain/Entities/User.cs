namespace Training_Shop.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public Address? Address { get; set; }
        public Cart Cart { get; set; } = null!;
        public User(string name) 
        {
            Name= name;
        }
    }
}
