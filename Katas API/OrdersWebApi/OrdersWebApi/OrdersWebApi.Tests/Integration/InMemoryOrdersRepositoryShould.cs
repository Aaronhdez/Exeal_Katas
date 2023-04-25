using FluentAssertions;
using OrdersWebApi.Model.Orders;

namespace OrdersWebApi.Tests.Integration;

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
            new Products( new[] { new Product("computerMonitor", 70) }));
        
        _inMemoryOrdersRepository.Create(expectedOrder);
        
        var retrievedOrder = _inMemoryOrdersRepository.GetById("ORD123456");
        retrievedOrder.Should().Be(expectedOrder);
    }
}