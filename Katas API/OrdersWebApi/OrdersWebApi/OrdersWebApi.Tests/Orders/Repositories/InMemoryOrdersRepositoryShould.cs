using FluentAssertions;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Repositories;
using OrdersWebApi.Products;

namespace OrdersWebApi.Tests.Orders.Repositories;

public class InMemoryOrdersRepositoryShould {
    private InMemoryOrdersRepository _inMemoryOrdersRepository;

    [SetUp]
    public void SetUp() {
        _inMemoryOrdersRepository = new InMemoryOrdersRepository();
    }

    [Test]
    public void InsertNewOrderRegistryWhileRequested() {
        var expectedOrder = new Order(TestDefaultValues.OrderId, TestDefaultValues.CreationDate, TestDefaultValues.CustomerName, TestDefaultValues.CustomerAddress,
            new List<Product> { TestDefaultValues.ComputerMonitor });

        _inMemoryOrdersRepository.Create(expectedOrder);

        var retrievedOrder = _inMemoryOrdersRepository.GetById(TestDefaultValues.OrderId).Result;
        retrievedOrder.Should().Be(expectedOrder);
    }


    [Test]
    public void UpdateAnOrderProductsListWhileRequested() {
        var expectedOrder = new Order(TestDefaultValues.OrderId, TestDefaultValues.CreationDate, TestDefaultValues.CustomerName, TestDefaultValues.CustomerAddress,
            new List<Product> { TestDefaultValues.ComputerMonitor });
        var expectedUpdatedOrder = new Order(TestDefaultValues.OrderId, TestDefaultValues.CreationDate, TestDefaultValues.CustomerName, TestDefaultValues.CustomerAddress,
            new List<Product> {
                TestDefaultValues.ComputerMonitor,
                TestDefaultValues.ComputerMonitor
            });

        _inMemoryOrdersRepository.Create(expectedOrder);
        _inMemoryOrdersRepository.Update(expectedUpdatedOrder);

        var retrievedOrder = _inMemoryOrdersRepository.GetById(TestDefaultValues.OrderId).Result;
        retrievedOrder.Should().Be(expectedUpdatedOrder);
    }
}