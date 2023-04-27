namespace OrdersWebApi.Orders.Controllers.Requests;

#pragma warning disable CS8602
public class AddProductsRequest
{
    public Product[] Products { get; }

    public AddProductsRequest(Product[] products)
    {
        Products = products;
    }
}