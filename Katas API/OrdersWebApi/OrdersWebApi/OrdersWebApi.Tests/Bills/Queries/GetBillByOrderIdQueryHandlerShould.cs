using FluentAssertions;
using NSubstitute;
using OrdersWebApi.Bills.Queries;
using OrdersWebApi.Orders;
using OrdersWebApi.Tests.Orders;
using OrdersWebApi.TestUtils;
using OrdersWebApi.TestUtils.Orders;

namespace OrdersWebApi.Tests.Bills.Queries;

public class GetBillByOrderIdQueryHandlerShould {
    private GetBillByOrderIdQueryHandler _handler;
    private IOrderRepository _ordersRepository;
    private Order _aTestOrder;

    [SetUp]
    public void SetUp() {
        _ordersRepository = Substitute.For<IOrderRepository>();
        _handler = new GetBillByOrderIdQueryHandler(_ordersRepository);
        _aTestOrder = OrdersMother.ATestOrderWithAProduct();
        _ordersRepository.GetById(_aTestOrder.Id).Returns(_aTestOrder);
    }

    [Test]
    public async Task RetrieveABillWithAnOrderId() {
        var receivedBillResponse = await _handler.Handle(
            new GetBillByOrderIdQuery(_aTestOrder.Id), default);

        receivedBillResponse.Should().BeEquivalentTo(BillsMother.ATestBill());
    }
}