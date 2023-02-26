using Microsoft.EntityFrameworkCore;
using Training_Shop.Models;

namespace Training_Shop.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;
        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Piłka",
                    Available = true,
                    Price = 44.99
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Deska",
                    Available = true,
                    Price = 10
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Auto",
                    Available = false,
                    Price = 13999
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Krzesło",
                    Available = true,
                    Price = 80.99
                },
                new Product
                {
                    ProductId = 5,
                    ProductName = "Laptop",
                    Available = false,
                    Price = 2500
                },
                new Product
                {
                    ProductId = 6,
                    ProductName = "Koszyk",
                    Available = true,
                    Price = 5.99
                },
                new Product
                {
                    ProductId = 7,
                    ProductName = "Tabica",
                    Available = false,
                    Price = 699.99
                },
                new Product
                {
                    ProductId = 8,
                    ProductName = "Kawiatek",
                    Available = true,
                    Price = 19.99
                }
             ); ;

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Name = "Dawid",
                    UserId = 1,
                },
                new User
                {
                    UserId = 2,
                    Name = "Agata"
                }
             );

            modelBuilder.Entity<Cart>().HasData(
                new Cart
                {
                    CartId = 1,
                    TotalQuantity = 3,
                    TotalPrice = 4,
                    UserId = 1
                },
                new Cart
                {
                    CartId = 2,
                    TotalQuantity = 6,
                    TotalPrice = 5,
                    UserId = 2
                }
             );
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    AddressId = 1,
                    Country = "Poland",
                    City = "Zabrze",
                    Street = "Hermisza",
                    UserId = 1
                },
                new Address
                {
                    AddressId = 2,
                    Country = "Poland",
                    City = "Warszawa",
                    Street = "Mokotowska",
                    UserId = 2
                }
             );
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem
                {
                    CartItemId = 1,
                    Quantity = 1,
                    CartId = 1,
                    ProductId =1,
                },
                new CartItem
                {
                    CartItemId = 2,
                    Quantity = 2,
                    CartId = 1,
                    ProductId = 2,
                },
                new CartItem
                {
                    CartItemId = 3,
                    Quantity = 10,
                    CartId = 1,
                    ProductId = 3,
                },
                new CartItem
                {
                    CartItemId = 4,
                    Quantity = 5,
                    CartId = 2,
                    ProductId = 4,
                },
                new CartItem
                {
                    CartItemId = 5,
                    Quantity = 6,
                    CartId = 2,
                    ProductId = 5,
                }
             );
        }
    }
}
