using System.Data.SQLite;
using Dapper;
using OrdersWebApi.Products;
using OrdersWebApi.Products.Queries;

namespace OrdersWebApi.Orders.Repositories;

public class SQLiteProductsRepository : IProductsRepository {
    private readonly SQLiteConnection _connection;

    public SQLiteProductsRepository(SQLiteConnection connection) {
        _connection = connection;
    }

    public async Task<ProductReadDto> GetById(string productId) {
        var product = await _connection.QueryFirstOrDefaultAsync<Product>($"SELECT * FROM Products WHERE ID = '{productId}'");
        return new ProductReadDto {
            Id = product.Id,
            ProductReference = "MON",
            Name = product.Name,
            Description = product.Description,
            Manufacturer = product.Manufacturer,
            ManufacturerReference = product.ManufacturerReference,
            Value = (int) product.Value
        };
    }

    public Task Create(Product product) {
        return _connection.ExecuteAsync(
            "INSERT INTO " +
            "Products(ID, Name, Value) " +
            $"VALUES('{product.Id}','{product.Name}',{product.Value})");
    }

}