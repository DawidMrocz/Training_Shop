using Dapper;
using System.Data.SqlClient;
using Training_Shop.Application.Common.Interfaces.Persistence;
using Training_Shop.Domain.Entities;

namespace Training_Shop.Infrastructure.Persistence.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly DapperContext _context;
        public ProductRepository(DapperContext context) 
        { 
            _context = context;
        } 
        public async Task<Product> GetProduct(int productId)
        {
            string sql = "SELECT productName,available,price FROM PRODUCTS WHERE ProductId = @id";
            var parameters = new { id = productId };

            var connection = _context.CreateConnection();
            
            Product product = await connection.QuerySingleOrDefaultAsync<Product>(sql, parameters);
            
            return product;
        }

        public async Task<IEnumerable<Product>> SearchProduct(string phrase)
        {
            string sql = "SELECT productName,available,price FROM PRODUCTS WHERE PRODUCTNAME LIKE @SearchBy";
            var parameters = new { SearchBy = "%" + phrase + "%" };

            var connection = _context.CreateConnection();
            
            IEnumerable<Product> products = await connection.QueryAsync<Product>(sql, parameters);
            return products;
        }
    }
}
