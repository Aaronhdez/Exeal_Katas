namespace OrdersWebApi.Products.Commands;

public record CreateProductDto(
    string Id,
    string Type,
    string Name,
    string Description,
    string Manufacturer,
    string ManufacturerReference,
    int Value
);