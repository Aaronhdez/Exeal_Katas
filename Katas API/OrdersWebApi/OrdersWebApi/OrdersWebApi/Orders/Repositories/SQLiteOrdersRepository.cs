using System.Data.SQLite;
using Dapper;

namespace OrdersWebApi.Orders.Repositories;

public class SQLiteOrdersRepository : IOrderRepository {
    private readonly SQLiteConnection _connection;

    public SQLiteOrdersRepository(SQLiteConnection connection) {
        _connection = connection;
    }

    public Task Create(Order order) {
        return _connection.ExecuteAsync(
            $"INSERT INTO " +
            $"Orders(ID, CreationDate, Customer, Address) " +
            $"VALUES('{order.Id}','{order.CreationDate}','{order.Customer}','{order.Address}')");
    }

    public Task<Order> GetById(string orderId) {
        return Task.FromResult(RetrievedOrder(OrderFound(orderId), ProductsAssociated(orderId)));
    }

    private dynamic? OrderFound(string orderId) {
        return _connection.QueryFirstOrDefaultAsync<dynamic?>(
            $"SELECT * FROM Orders WHERE ID = '{orderId}'").Result;
    }

    private List<Product?> ProductsAssociated(string orderId) {
        return _connection.QueryAsync<Product?>(
                $"SELECT Products.Id as [id], Products.Name as name, Products.Value as [value] FROM Products " +
                $"JOIN OrdersProducts ON Products.ID = OrdersProducts.ProductID " +
                $"WHERE OrdersProducts.OrderID = '{orderId}'")
            .Result.ToList();
    }

    public Task Update(Order updatedOrder) {
        UpdateOrderData(updatedOrder);
        return UpdateProducts(updatedOrder);
    }

    private void UpdateOrderData(Order updatedOrder) {
        _connection.ExecuteAsync(
            $"UPDATE ORDERS SET (Address = '{updatedOrder.Address}', Customer = '{updatedOrder.Customer}') " +
            $"WHERE OrderId = '{updatedOrder.Id}'");
    }

    private Task UpdateProducts(Order updatedOrder) {
        _connection.ExecuteAsync(
            $"DELETE FROM OrdersProducts WHERE OrderId = '{updatedOrder.Id}'");

        foreach (var product in updatedOrder.Products.ProductsList) {
            _connection.ExecuteAsync($"INSERT INTO OrdersProducts(ProductID, OrderId) VALUES('{product.Id}', '{updatedOrder.Id}')");
        }
        return _connection.ExecuteAsync($"Insert FROM OrdersProducts WHERE OrderId = '{updatedOrder.Id}'");
    }

    private static Order RetrievedOrder(dynamic? orderFound, List<Product?> productsAssociated) {
        return new Order(orderFound.ID, orderFound.CreationDate, orderFound.Customer, orderFound.Address,
            new Products(productsAssociated));
    }
}