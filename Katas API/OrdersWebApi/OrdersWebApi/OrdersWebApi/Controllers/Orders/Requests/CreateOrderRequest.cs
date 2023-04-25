using OrdersWebApi.Model.Orders;

namespace OrdersWebApi.Controllers.Orders.Requests;

#pragma warning disable CS8602
public class CreateOrderRequest
{
    public readonly string Customer;
    public readonly string Address;
    public readonly Product[] Products;

    public CreateOrderRequest(string customer, string address, Product[] products)
    {
        Customer = customer;
        Address = address;
        Products = products;
    }
}