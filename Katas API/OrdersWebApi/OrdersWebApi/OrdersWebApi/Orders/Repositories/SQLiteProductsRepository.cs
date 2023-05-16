using System.Data.SQLite;
using Dapper;
using OrdersWebApi.Tests.Products;

namespace OrdersWebApi.Orders.Repositories;

public class SQLiteProductsRepository : IProductsRepository {
    private readonly SQLiteConnection _connection;

    public SQLiteProductsRepository(SQLiteConnection connection) {
        _connection = connection;
    }

    public async Task<ProductReadDto> GetById(string productId) {
        var item = await _connection.QueryFirstOrDefaultAsync<Item>($"SELECT * FROM Products WHERE ID = '{productId}'");
        return new ProductReadDto {
            Id = item.Id,
            ProductReference = "MON",
            Name = item.Name,
            Description = item.Description,
            Manufacturer = item.Manufacturer,
            ManufacturerReference = item.ManufacturerReference,
            Value = (int) item.Value
        };
    }

    public Task Create(Item item) {
        return _connection.ExecuteAsync(
            "INSERT INTO " +
            "Products(ID, Name, Value) " +
            $"VALUES('{item.Id}','{item.Name}',{item.Value})");
    }

}