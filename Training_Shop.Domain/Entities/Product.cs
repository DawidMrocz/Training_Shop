using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Shop.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public Product(string productName) 
        {
            ProductName = productName;
        }
    }
}
