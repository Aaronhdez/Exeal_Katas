using OrdersWebApi.Products;

namespace OrdersWebApi.Orders.Commands.AddProductsToOrder;

#pragma warning disable CS8602
public class AddProductsDto {
    public AddProductsDto(string id, Product[] products) {
        Id = id;
        Products = products;
    }

    public string Id { get; set; }
    public Product[] Products { get; set; }
}