using FluentAssertions;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Repositories;

namespace OrdersWebApi.Tests.Orders.Repositories;

public class InMemoryOrdersRepositoryShould 
{
    private InMemoryOrdersRepository _inMemoryOrdersRepository;

    [SetUp]
    public void SetUp()
    {
        _inMemoryOrdersRepository = new InMemoryOrdersRepository();
    }

    [Test]
    public void InsertNewOrderRegistryWhileRequested()
    {
        var expectedOrder = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new Products( new List<Product> { new("computerMonitor", 70) }));
        
        _inMemoryOrdersRepository.Create(expectedOrder);
        
        var retrievedOrder = _inMemoryOrdersRepository.GetById("ORD123456").Result;
        retrievedOrder.Should().Be(expectedOrder);
    }
    
    
    [Test]
    public void UpdateAnOrderProductsListWhileRequested()
    {
        var expectedOrder = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new Products( new List<Product> { new("computerMonitor", 70) }));
        var expectedUpdatedOrder = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new Products( new List<Product>
            {
                new("computerMonitor", 70),
                new("computerMonitor", 70),
            }));
        
        _inMemoryOrdersRepository.Create(expectedOrder);
        _inMemoryOrdersRepository.Update(expectedOrder);
        
        var retrievedOrder = _inMemoryOrdersRepository.GetById("ORD123456").Result;
        retrievedOrder.Should().Be(expectedUpdatedOrder);
    }
}