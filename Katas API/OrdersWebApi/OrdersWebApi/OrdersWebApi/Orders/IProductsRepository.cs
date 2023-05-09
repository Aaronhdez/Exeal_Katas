namespace OrdersWebApi.Orders;

public interface IProductsRepository {
    Task<Item> GetById(string productId);
    Task Create(Item item);
}