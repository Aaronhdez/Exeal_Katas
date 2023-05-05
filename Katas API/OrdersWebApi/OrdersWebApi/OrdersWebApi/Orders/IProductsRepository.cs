namespace OrdersWebApi.Orders;

public interface IProductsRepository {
    Task<Product> GetById(string productId);
    Task Create(Product product);
}