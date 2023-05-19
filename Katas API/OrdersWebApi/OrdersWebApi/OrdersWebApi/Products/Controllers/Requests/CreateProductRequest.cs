namespace OrdersWebApi.Products.Controllers.Requests;

public record CreateProductRequest(
    string Type,
    string Name,
    string Description,
    string Manufacturer,
    string ManufacturerReference,
    int Value);