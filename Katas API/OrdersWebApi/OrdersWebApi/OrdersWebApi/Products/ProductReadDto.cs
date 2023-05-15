namespace OrdersWebApi.Tests.Products;

public record ProductReadDto(string Id, string ProductReference, string Name, string Description, string Manufacturer, string ManufacturerReference, int Value);