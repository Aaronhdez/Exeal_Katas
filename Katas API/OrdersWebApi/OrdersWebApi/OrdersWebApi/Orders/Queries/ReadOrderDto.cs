using OrdersWebApi.Products;

namespace OrdersWebApi.Orders.Queries;

public record ReadOrderDto(
    string Id,
    string CreationDate,
    string Customer,
    string Address,
    List<Product> Products
);