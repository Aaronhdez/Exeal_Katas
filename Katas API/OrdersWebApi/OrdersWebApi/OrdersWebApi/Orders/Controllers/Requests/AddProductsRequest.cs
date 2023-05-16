using OrdersWebApi.Products;

namespace OrdersWebApi.Orders.Controllers.Requests;

#pragma warning disable CS8602
public class AddProductsRequest {
    public AddProductsRequest(Product[] products) {
        Products = products;
    }

    public Product[] Products { get; }
}