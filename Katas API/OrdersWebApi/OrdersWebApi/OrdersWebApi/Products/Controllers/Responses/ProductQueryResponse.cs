namespace OrdersWebApi.Products.Controllers.Responses;

public record ProductQueryResponse (string Id, string ProductReference, string Name, string Description, string Manufacturer, string ManufacturerReference, int Value);