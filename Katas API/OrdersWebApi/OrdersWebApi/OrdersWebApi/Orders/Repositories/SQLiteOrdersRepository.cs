using System.Data.SQLite;
using Dapper;

namespace OrdersWebApi.Orders.Repositories;

public class SQLiteOrdersRepository : IOrderRepository
{
    private readonly SQLiteConnection _connection;

    public SQLiteOrdersRepository(SQLiteConnection connection)
    {
        _connection = connection;
    }

    public Task Create(Order order)
    {
        return _connection.ExecuteAsync(
            $"INSERT INTO " +
            $"Orders(ID, CreationDate, Customer, Address) " +
            $"VALUES('{order.Id}','{order.CreationDate}','{order.Customer}','{order.Address}')");
    }

    public Task<Order> GetById(string orderId)
    {
        var orderQuery = GetOrderFrom(orderId);
        var productsAssociated = GetProductsAssociatedTo(orderId);
        return Task.FromResult(RetrievedOrder(orderQuery, productsAssociated));
    }

    private dynamic? GetOrderFrom(string orderId)
    {
        return _connection.QueryFirstOrDefaultAsync<dynamic?>($"SELECT * FROM Orders WHERE ID = '{orderId}'").Result;
    }

    private List<Product?> GetProductsAssociatedTo(string id)
    {
        return _connection.QueryAsync<Product?>(
                $"SELECT Products.Id as [id], Products.Name as name, Products.Value as [value] " +
                $"FROM Products " +
                $"JOIN OrdersProducts ON Products.ID = OrdersProducts.ProductID " +
                $"WHERE OrdersProducts.OrderID = '{id}'")
            .Result.ToList();
    }

    private static Order RetrievedOrder(dynamic? orderFound, List<Product?> productsAssociated)
    {
        var order = new Order(
            orderFound.ID,
            orderFound.CreationDate,
            orderFound.Customer,
            orderFound.Address,
            new Products(productsAssociated));
        return order;
    }

    public Task Update(Order orderModel)
    {
        throw new NotImplementedException();
    }
}