using OrdersWebApi.Products;

namespace OrdersWebApi.Orders.Controllers.Requests;

#pragma warning disable CS8602
public class CreateOrderRequest {
    public CreateOrderRequest(string customer, string address, string[] products) {
        Customer = customer;
        Address = address;
        Products = products;
    }
    public string Customer { get; }
    public string Address { get; }
    public string[] Products { get; }
}