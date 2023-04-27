using FluentAssertions;
using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Queries;

namespace OrdersWebApi.Tests.Orders.Queries;

public class GetOrderByIdShould
{
    private IOrderRepository _ordersRepository;
    private GetOrderByIdQuery _getOrderByIdQuery;

    [SetUp]
    public void SetUp()
    {
        _ordersRepository = Substitute.For<IOrderRepository>();
        _getOrderByIdQuery = new GetOrderByIdQuery(_ordersRepository);
    }

    [Test]
    public async Task RetrieveAnOrderByItsIdWhileRequested()
    {
        _ordersRepository.GetById("ORD123456").Returns(new Order("ORD123456", null, null, null, null));

        var receivedOrderResponse = _getOrderByIdQuery.Execute("ORD123456");

        receivedOrderResponse.Should().NotBeNull();
    }
}