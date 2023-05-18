using System.Data.SQLite;
using Dapper;

namespace OrdersWebApi.Products.Repositories;

public class SQLiteProductsRepository : IProductsRepository {
    private readonly SQLiteConnection _connection;

    public SQLiteProductsRepository(SQLiteConnection connection) {
        _connection = connection;
    }

    public async Task<Product> GetById(string productId) {
        return await _connection.QueryFirstOrDefaultAsync<Product>($"SELECT * FROM Products WHERE ID = '{productId}'");
    }

    public Task<IEnumerable<Product>> GetAllProductsForTag(string tag) {
        throw new NotImplementedException();
    }

    public Task Create(Product product) {
        return _connection.ExecuteAsync(
            "INSERT INTO " +
            "Products(ID, Name, Value) " +
            $"VALUES('{product.Id}','{product.Name}',{product.Value})");
    }

}