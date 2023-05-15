using OrdersWebApi.Tests.Products;

namespace OrdersWebApi.Orders;

public interface IProductsRepository {
    Task<Item> GetById(string productId);
    Task Create(Item item);
    Task<ProductReadDto> GetReadDtoById(string productId);
}