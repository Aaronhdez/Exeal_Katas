namespace OrdersWebApi.Products.Queries;

public class ProductReadDto {
    public string Id { get; set; }
    public string ProductReference { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Manufacturer { get; set; }
    public string ManufacturerReference { get; set; }
    public int Value { get; set; }
}
