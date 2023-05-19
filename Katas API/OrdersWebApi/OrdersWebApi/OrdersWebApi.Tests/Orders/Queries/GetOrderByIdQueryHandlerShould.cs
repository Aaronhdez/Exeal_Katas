using FluentAssertions;
using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Queries;
using OrdersWebApi.Orders.Repositories;

namespace OrdersWebApi.Tests.Orders.Queries;

public class GetOrderByIdQueryHandlerShould {
    private GetOrderByIdQuery _getOrderByIdQuery;
    private GetOrderByIdQueryHandler _handler;
    private IOrderRepository _ordersRepository;

    [SetUp]
    public void SetUp() {
        _ordersRepository = new InMemoryOrdersRepository();
        _handler = new GetOrderByIdQueryHandler(_ordersRepository);
    }

    [Test]
    public async Task RetrieveAnOrderByItsIdWhileRequested() {
        var testOrder = OrdersMother.ATestOrderWithoutProducts();
        await _ordersRepository.Create(testOrder);

        var receivedOrderResponse = await _handler.Handle(
            new GetOrderByIdQuery(testOrder.Id), default);

        var expectedOrder = OrdersMother.TestOrderReadDto();
        receivedOrderResponse.Should().BeEquivalentTo(expectedOrder);
    }
}