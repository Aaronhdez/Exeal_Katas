using OrdersWebApi.Products;
using OrdersWebApi.Users.Queries;

namespace OrdersWebApi.Orders.Queries;

public record ReadOrderDto(
    string Id,
    string CreationDate,
    ReadUserDto Vendor,
    ReadUserDto Customer,
    List<Product> Products
);