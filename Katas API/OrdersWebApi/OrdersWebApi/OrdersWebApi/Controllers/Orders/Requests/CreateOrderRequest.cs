using System.Text.Json.Serialization;
using OrdersWebApi.Models.Orders;

namespace OrdersWebApi.Controllers.Orders.Requests;

#pragma warning disable CS8602
public class CreateOrderRequest
{
    public string Customer { get; set; }
    public string Address { get; set; }
    public Product[] Products { get; set; }

    public CreateOrderRequest(string customer, string address, Product[] products)
    {
        Customer = customer;
        Address = address;
        Products = products;
    }
}