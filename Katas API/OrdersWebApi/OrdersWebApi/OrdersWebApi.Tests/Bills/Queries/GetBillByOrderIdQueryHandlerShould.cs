using FluentAssertions;
using NSubstitute;
using OrdersWebApi.Bills.Queries;
using OrdersWebApi.Orders;
using OrdersWebApi.Tests.Orders;

namespace OrdersWebApi.Tests.Bills.Queries;

public class GetBillByOrderIdQueryHandlerShould {
    private GetBillByOrderIdQueryHandler _handler;
    private IOrderRepository _ordersRepository;

    [SetUp]
    public void SetUp() {
        _ordersRepository = Substitute.For<IOrderRepository>();
        _handler = new GetBillByOrderIdQueryHandler(_ordersRepository);
    }

    [Test]
    public async Task RetrieveABillWithAnOrderId() {
        _ordersRepository.GetById(OrderDefaultValues.OrderId).Returns(OrdersMother.ATestOrderWithAProduct());

        var receivedBillResponse =
            await _handler.Handle(new GetBillByOrderIdQuery(OrderDefaultValues.OrderId), default);

        var expectedBillResponse = BillsMother.ATestBill();
        receivedBillResponse.Should().BeEquivalentTo(expectedBillResponse);
    }
}