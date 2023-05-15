using System.Data.SQLite;
using Dapper;
using OrdersWebApi.Tests.Products;

namespace OrdersWebApi.Orders.Repositories;

public class SQLiteProductsRepository : IProductsRepository {
    private readonly SQLiteConnection _connection;

    public SQLiteProductsRepository(SQLiteConnection connection) {
        _connection = connection;
    }

    public Task<Item> GetById(string productId) {
        return _connection.QueryFirstOrDefaultAsync<Item>($"SELECT * FROM Products WHERE ID = '{productId}'");
    }

    public Task Create(Item item) {
        return _connection.ExecuteAsync(
            "INSERT INTO " +
            "Products(ID, Name, Value) " +
            $"VALUES('{item.Id}','{item.Name}',{item.Value})");
    }

    public Task<ProductReadDto> GetReadDtoById(string productId) {
        return _connection.QueryFirstOrDefaultAsync<ProductReadDto>($"SELECT * FROM Products WHERE ID = '{productId}'");
    }
}