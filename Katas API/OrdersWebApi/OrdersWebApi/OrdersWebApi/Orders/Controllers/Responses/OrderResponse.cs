using OrdersWebApi.Products;
using OrdersWebApi.Users;
using OrdersWebApi.Users.Controllers;

namespace OrdersWebApi.Orders.Controllers.Responses;

#pragma warning disable CS8602
public record OrderResponse(
    string Id,
    string CreationDate,
    ReadUserResponse Vendor,
    ReadUserResponse Customer,
    List<Product> Products);