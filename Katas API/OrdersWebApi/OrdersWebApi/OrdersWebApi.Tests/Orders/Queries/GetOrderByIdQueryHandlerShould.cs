using FluentAssertions;
using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Queries;

namespace OrdersWebApi.Tests.Orders.Queries;

public class GetOrderByIdQueryHandlerShould
{
    private IOrderRepository _ordersRepository;
    private GetOrderByIdQuery _getOrderByIdQuery;
    private GetOrderByIdQueryHandler _handler;

    [SetUp]
    public void SetUp()
    {
        _ordersRepository = Substitute.For<IOrderRepository>();
        _handler = new GetOrderByIdQueryHandler(_ordersRepository);
    }

    [Test]
    public async Task RetrieveAnOrderByItsIdWhileRequested()
    {
        _ordersRepository.GetById("ORD123456").Returns(new Order("ORD123456", null, null, null, null));

        var receivedOrderResponse = _handler.Handle(new GetOrderByIdQuery("ORD123456"), default);
        
        receivedOrderResponse.Should().NotBeNull();
    }
}