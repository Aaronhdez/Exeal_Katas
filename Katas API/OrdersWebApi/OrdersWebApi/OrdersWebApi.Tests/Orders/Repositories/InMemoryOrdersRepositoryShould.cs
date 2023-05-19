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
    public async Task InsertNewOrderRegistryWhileRequested() {
        var expectedOrder = OrdersMother.ATestOrderWithAProduct();

        await _inMemoryOrdersRepository.Create(expectedOrder);

        var retrievedOrder = await _inMemoryOrdersRepository.GetById(expectedOrder.Id);
        retrievedOrder.Should().Be(expectedOrder);
    }
    
    [Test]
    public async Task UpdateAnOrderProductsListWhileRequested() {
        var expectedOrder = OrdersMother.ATestOrderWithAProduct();
        var expectedUpdatedOrder = OrdersMother.AnUpdatedTestOrderWithTwoProducts();

        await _inMemoryOrdersRepository.Create(expectedOrder);
        await _inMemoryOrdersRepository.Update(expectedUpdatedOrder);

        var retrievedOrder = await _inMemoryOrdersRepository.GetById(expectedOrder.Id);
        retrievedOrder.Should().Be(expectedUpdatedOrder);
    }
}