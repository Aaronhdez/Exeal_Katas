using OrdersWebApi.Products;

namespace OrdersWebApi.Orders.Commands.CreateOrder;

#pragma warning disable CS8602
public class CreateOrderDto {
    public CreateOrderDto(string id, string customer, string address, string[] products) {
        Id = id;
        Customer = customer;
        Address = address;
        Products = products;
    }

    public string Id { get; }
    public string Customer { get; }
    public string Address { get; }
    public string[] Products { get; }
}
