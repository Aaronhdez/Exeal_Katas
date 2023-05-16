using OrdersWebApi.Products.Queries;

namespace OrdersWebApi.Products;

public interface IProductsRepository {
    //Task<Product> GetById(string productId);
    Task Create(Product product);
    Task<Product> GetById(string productId);
    Task<IEnumerable<Product>> GetAllProductsForTag(string tag);
}