using System.Text.Json.Serialization;
using OrdersWebApi.Models.Orders;

namespace OrdersWebApi.Controllers.Orders.Requests;

#pragma warning disable CS8602
public class CreateOrderRequest
{
    public string Id { get; }
    public string Customer { get; }
    public string Address { get; }
    public Product[] Products { get; }

    public CreateOrderRequest(string id, string customer, string address, Product[] products)
    {
        Id = id;
        Customer = customer;
        Address = address;
        Products = products;
    }
}