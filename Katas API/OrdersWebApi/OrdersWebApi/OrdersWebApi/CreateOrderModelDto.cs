namespace OrdersWebApi;

public class CreateOrderModelDto
{
    private string Id { get; }
    private string Timestamp { get; }
    private string Customer { get; }
    private string Address { get; }
    private Product[] Products { get; }

    public CreateOrderModelDto(string id, string timestamp, string customer, string address, Product[] products)
    {
        Id = id;
        Timestamp = timestamp;
        Customer = customer;
        Address = address;
        Products = products;
    }
}