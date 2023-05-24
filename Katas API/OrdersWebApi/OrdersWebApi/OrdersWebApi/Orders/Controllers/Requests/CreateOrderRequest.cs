namespace OrdersWebApi.Orders.Controllers.Requests;

#pragma warning disable CS8602
public record CreateOrderRequest(
    string VendorId,
    string CustomerId,
    string[] Products);