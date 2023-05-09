namespace OrdersWebApi.Orders.Commands.AddProductsToOrder;

#pragma warning disable CS8602
public class AddProductsDto {
    public AddProductsDto(string id, Item[] products) {
        Id = id;
        Products = products;
    }

    public string Id { get; set; }
    public Item[] Products { get; set; }
}