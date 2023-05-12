namespace OrdersWebApi.Products;

public record CreateProductDto(
    string type,
    string name,
    string decription,
    string manufacturer,
    string manufacturerReference,
    int value
);