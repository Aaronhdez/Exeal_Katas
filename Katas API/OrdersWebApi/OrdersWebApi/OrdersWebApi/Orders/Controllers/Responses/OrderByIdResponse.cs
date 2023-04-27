using OrdersWebApi.Models.Orders;

namespace OrdersWebApi.Controllers.Orders;

#pragma warning disable CS8602
public class OrderResponse
{
    public string Id { get; set; }
    public string CreationDate { get; set; }
    public string Address { get; set; }
    public string Customer { get; set; }
    public Products Products { get; set; }
}