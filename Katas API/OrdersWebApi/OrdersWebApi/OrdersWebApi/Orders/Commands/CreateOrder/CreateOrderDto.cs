using OrdersWebApi.Products;

namespace OrdersWebApi.Orders.Commands.CreateOrder;

#pragma warning disable CS8602
public class CreateOrderDto {
    public CreateOrderDto(string id, string customer, string address, Product[] products) {
        Id = id;
        Customer = customer;
        Address = address;
        Products = products;
    }

    public string Id { get; }
    public string Customer { get; }
    public string Address { get; }
    public Product[] Products { get; }
}