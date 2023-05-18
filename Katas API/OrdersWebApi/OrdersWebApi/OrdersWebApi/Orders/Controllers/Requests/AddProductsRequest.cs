using OrdersWebApi.Products;

namespace OrdersWebApi.Orders.Controllers.Requests;

#pragma warning disable CS8602
public record AddProductsRequest(string[] Products);