using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using Training_Shop.Dto;
using Training_Shop.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Training_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        private readonly IConfiguration _config;

        public CartController(ILogger<CartController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        //[HttpGet]
        ////[Route("/{userId}")]
        //public async Task<ActionResult<CartDto>> GetCart()
        //{
        //    using SqlConnection connection = new(_config.GetConnectionString("DefaultConnection"));

        //    //var sql = @"SELECT Carts.Price,Carts.Quantity,Users.UserId,Users.Name FROM Carts INNER JOIN Users ON Carts.UserId = Users.UserId";

        //    var sql = @"SELECT * FROM Carts 
        //        INNER JOIN Users ON Carts.UserId = Users.UserId
        //        INNER JOIN CartItems ON Carts.CartId = CartItems.CartId
        //        INNER JOIN Products ON Products.ProductId = CartItems.ProductId";

        //    var cart = await connection.QueryAsync<Cart,User,CartItem,Cart>(sql, (cart, user, cartItem) => {
        //        cart.User = user;
        //        cart.CartItems.Add(cartItem);
        //        return cart;
        //    }, splitOn: "UserId,CartId");

        //    var result = cart.GroupBy(p => p.CartId).Select(g => new CartDto()
        //    {
        //        CartId = g.Key,
        //        Quantity = g.First().Quantity,
        //        Price = g.First().Price,
        //        Name = g.First().User.Name,
        //        CartItems = g.First().CartItems.Select(item => new CartItemDto()
        //        {
        //            CartItemId = item.CartItemId,
        //            Quantity = item.Quantity,
        //        }).ToList()
        //    });        

        //    return Ok(result);
        //}




        [HttpGet]
        //[Route("/{userId}")]
        public async Task<ActionResult<Cart>> GetCart2()
        {
            using SqlConnection connection = new(_config.GetConnectionString("DefaultConnection"));

            //var sql = @"SELECT Carts.Price,Carts.Quantity,Users.UserId,Users.Name FROM Carts INNER JOIN Users ON Carts.UserId = Users.UserId";

            var sql = @"SELECT * FROM Carts
                INNER JOIN Users ON Carts.UserId = Users.UserId
                INNER JOIN Addresses ON Users.UserId = Addresses.UserId
                INNER JOIN CartItems ON Carts.CartId = CartItems.CartId
                INNER JOIN Products ON CartItems.ProductId = Products.ProductId";

            var cartDictionary = new Dictionary<int, Cart>();

            var cart = await connection.QueryAsync<Cart>(sql,
                new[]
                {
                    typeof(Cart),
                    typeof(User),
                    typeof(Address),
                    typeof(CartItem),
                    typeof(Product)
                }
                , obj =>
            {

                Cart cart = obj[0] as Cart;
                User user = obj[1] as User;
                Address address = obj[2] as Address;
                CartItem cartItem = obj[3] as CartItem;
                Product product = obj[4] as Product;

                cart.User = user;
                cart.User.Address = address;

                if (cart.CartItems is null)
                {
                    cart.CartItems = new List<CartItem>();
                }
                
                cart.CartItems.Add(cartItem);
                cart.CartItems.First().Product = product;
                return cart;

            }, splitOn: "UserId,AddressId,CartItemId,ProductId");

            var result = cart.GroupBy(p => p.CartId).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.CartItems = g.Select(p => p.CartItems.Single()).ToList();
                return groupedPost;
            });

            //var result = cart.GroupBy(p => p.CartId).Select(g => new CartDto()
            //{
            //    CartId = g.Key,
            //    Quantity = g.First().Quantity,
            //    Price = g.First().Price,
            //    Name = g.First().User.Name,
            //    CartItems = g.First().CartItems.Select(item => new CartItemDto()
            //    {
            //        CartItemId = item.CartItemId,
            //        Quantity = item.Quantity,
            //    }).ToList()
            //});

            return Ok(result);
        }


    }
}
