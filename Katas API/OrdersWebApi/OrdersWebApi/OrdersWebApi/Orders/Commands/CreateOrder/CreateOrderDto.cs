namespace OrdersWebApi.Orders.Commands.CreateOrder;

#pragma warning disable CS8602
public class CreateOrderDto {
    public CreateOrderDto(string customer, string address, Item[] products) {
        Customer = customer;
        Address = address;
        Products = products;
    }

    public string Customer { get; }
    public string Address { get; }
    public Item[] Products { get; }
}