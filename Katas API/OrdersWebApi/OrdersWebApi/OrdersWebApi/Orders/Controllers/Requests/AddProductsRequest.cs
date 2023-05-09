namespace OrdersWebApi.Orders.Controllers.Requests;

#pragma warning disable CS8602
public class AddProductsRequest {
    public AddProductsRequest(Item[] products) {
        Products = products;
    }

    public Item[] Products { get; }
}