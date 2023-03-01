using Training_Shop.Domain.Entities;

namespace Training_Shop.Application.Common.Interfaces.Persistence
{
    public interface IProductRepository
    {
        //public async Task<List<Product>> GetProducts(QueryParams query);
        public Task<Product> GetProduct(int productId);
        public Task<IEnumerable<Product>> SearchProduct(string phrase);
        //public async Task<List<Product>> CreateProduct(CreateProduct product);
        //public async Task<Product> UpdateProduct(UpdateProduct product);
        //public async Task<List<Product>> DeleteProduct(int productId);
    }
}
