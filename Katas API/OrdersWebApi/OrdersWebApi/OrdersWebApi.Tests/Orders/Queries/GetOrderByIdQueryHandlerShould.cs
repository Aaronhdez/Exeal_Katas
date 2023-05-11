using FluentAssertions;
using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Queries;
using OrdersWebApi.Tests.Acceptance;

namespace OrdersWebApi.Tests.Orders.Queries;

public class GetOrderByIdQueryHandlerShould {
    private GetOrderByIdQuery _getOrderByIdQuery;
    private GetOrderByIdQueryHandler _handler;
    private IOrderRepository _ordersRepository;

    [SetUp]
    public void SetUp() {
        _ordersRepository = Substitute.For<IOrderRepository>();
        _handler = new GetOrderByIdQueryHandler(_ordersRepository);
    }

    [Test]
    public async Task RetrieveAnOrderByItsIdWhileRequested() {
        _ordersRepository.GetById(TestDefaultValues.OrderId).Returns(new Order(TestDefaultValues.OrderId, null, null, null, null));

        var receivedOrderResponse = _handler.Handle(new GetOrderByIdQuery(TestDefaultValues.OrderId), default);

        receivedOrderResponse.Should().NotBeNull();
    }
}