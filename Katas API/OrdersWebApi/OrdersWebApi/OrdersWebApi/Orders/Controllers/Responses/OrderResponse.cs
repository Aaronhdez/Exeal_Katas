using OrdersWebApi.Products;

namespace OrdersWebApi.Orders.Controllers.Responses;

#pragma warning disable CS8602
public record OrderResponse(
    string Id,
    string CreationDate,
    string Address,
    string Customer,
    List<Product> Products);