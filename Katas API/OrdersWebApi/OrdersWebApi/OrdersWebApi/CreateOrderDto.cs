namespace OrdersWebApi;

#pragma warning disable CS8602
public class CreateOrderDto
{
    public string Id { get; }
    DateTime Timestamp { get; }
    public string Customer { get; }
    public string Address { get; }
    public Product[] Products { get; }

    public CreateOrderDto(string id, DateTime timestamp, string customer, string address, Product[] products)
    {
        Id = id;
        Timestamp = timestamp;
        Customer = customer;
        Address = address;
        Products = products;
    }
}