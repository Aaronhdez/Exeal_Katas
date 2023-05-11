using FluentAssertions;
using NSubstitute;
using OrdersWebApi.Bills;
using OrdersWebApi.Orders;
using OrdersWebApi.Tests.Acceptance;

namespace OrdersWebApi.Tests.Bills.Queries;

public class GetBillByOrderIdQueryHandlerShould {
    private IOrderRepository _ordersRepository;
    private GetBillByOrderIdQueryHandler _handler;

    [SetUp]
    public void SetUp() {
        _ordersRepository = Substitute.For<IOrderRepository>();
        _handler = new GetBillByOrderIdQueryHandler(_ordersRepository);
    }

    [Test]
    public void RetrieveABillWithAnOrderId() {
        _ordersRepository.GetById(TestDefaultValues.OrderId).Returns(TestDefaultValues.AnOrder);

        var receivedBillResponse = _handler.Handle(new GetBillByOrderIdQuery(TestDefaultValues.OrderId), default);

        var expectedBillResponse = new ReadBillDto { };
        receivedBillResponse.Should().Be(expectedBillResponse);
    }
}