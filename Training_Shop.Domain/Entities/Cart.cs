using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Shop.Domain.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
