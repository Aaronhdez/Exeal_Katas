namespace OrdersWebApi.Orders.Commands.Dto;

#pragma warning disable CS8602
public class CreateOrderDto
{
    public string Customer { get; }
    public string Address { get; }
    public Product[] Products { get; }

    public CreateOrderDto(string customer, string address, Product[] products)
    {
        Customer = customer;
        Address = address;
        Products = products;
    }
}