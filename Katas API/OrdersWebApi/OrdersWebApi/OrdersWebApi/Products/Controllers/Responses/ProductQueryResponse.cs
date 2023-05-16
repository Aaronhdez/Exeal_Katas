namespace OrdersWebApi.Products;

public record ProductQueryResponse (string Id, string ProductReference, string Name, string Description, string Manufacturer, string ManufacturerReference, int Value);