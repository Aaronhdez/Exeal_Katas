using OrdersWebApi.Products.Queries;

namespace OrdersWebApi.Products;

public interface IProductsRepository {
    Task Create(Product product);
    Task<Product> GetById(string productId);
    Task<IEnumerable<Product>> GetAllProductsForTag(string tag);
}