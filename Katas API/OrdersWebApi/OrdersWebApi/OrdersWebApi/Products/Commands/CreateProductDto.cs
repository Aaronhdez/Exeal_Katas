namespace OrdersWebApi.Products;

public record CreateProductDto(
    string Id,
    string Type,
    string Name,
    string Description,
    string Manufacturer,
    string ManufacturerReference,
    int Value
);