using FluentAssertions;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Repositories;

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

        expectedOrder.Should().Be(await _inMemoryOrdersRepository.GetById(expectedOrder.Id));
    }

    [Test]
    public async Task UpdateAnOrderProductsListWhileRequested() {
        var expectedOrder = OrdersMother.ATestOrderWithAProduct();
        var expectedUpdatedOrder = OrdersMother.AnUpdatedTestOrderWithTwoProducts();

        await _inMemoryOrdersRepository.Create(expectedOrder);
        await _inMemoryOrdersRepository.Update(expectedUpdatedOrder);

        expectedUpdatedOrder.Should().Be(await _inMemoryOrdersRepository.GetById(expectedOrder.Id));
    }
}