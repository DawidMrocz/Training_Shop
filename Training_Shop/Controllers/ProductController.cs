using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Training_Shop.Dto;
using Training_Shop.Models;

namespace Training_Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IConfiguration _config;

        public ProductController(ILogger<ProductController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery]QueryParams query)
        {
            using SqlConnection connection = new(_config.GetConnectionString("DefaultConnection"));
            string sql = "SELECT productName,available,price AS Cena FROM PRODUCTS WHERE AVAILABLE = @AVAILABLE AND PRICE > @PRICE ORDER BY productName ASC";
            var parameters = new { AVAILABLE = query.Available,PRICE = query.Price};
            IEnumerable<Product> product = await connection.QueryAsync<Product>(sql, parameters);
            return Ok(product);
        }

        [HttpGet]
        [Route("/product/{productId}")]
        public async Task<ActionResult<Product>> GetProduct([FromRoute] int productId)
        {
            using SqlConnection connection = new(_config.GetConnectionString("DefaultConnection"));
            string sql = "SELECT productName,available,price FROM PRODUCTS WHERE ProductId = @id";
            var parameters = new { id = productId };
            Product product = await connection.QuerySingleOrDefaultAsync<Product>(sql, parameters);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet]
        [Route("/Search")]
        public async Task<ActionResult<Product>> SearchProduct([FromQuery] string phrase)
        {
            using SqlConnection connection = new(_config.GetConnectionString("DefaultConnection"));
            string sql = "SELECT productName,available,price FROM PRODUCTS WHERE PRODUCTNAME LIKE @SearchBy";
            var parameters = new { SearchBy = "%" + phrase + "%" };
            IEnumerable<Product> products = await connection.QueryAsync<Product>(sql, parameters);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> CreateProduct([FromBody]CreateProduct product)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into Products (ProductName, Price, Available) values (@ProductName, @Price, @Available)", product);
            return Ok(await SelectAllProducts(connection));
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] UpdateProduct product)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            string sql = "UPDATE PRODUCTS SET PRODUCTNAME = @ProductName,PRICE = @Price,AVAILABLE = @Available WHERE ProductId = @ProductId";
            await connection.ExecuteAsync(sql, product);
            return base.Ok(await SelectAllProducts(connection));
        }

        [HttpDelete]
        [Route("/{productId}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct([FromRoute]int productId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from Products where ProductId = @Id", new { Id = productId });
            return Ok(await SelectAllProducts(connection));
        }

        private static async Task<IEnumerable<dynamic>> SelectAllProducts(SqlConnection connection)
        {
            return await connection.QueryAsync("SELECT * FROM PRODUCTS");
        }

    }
}