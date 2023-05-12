using FluentAssertions;
using NSubstitute;
using OrdersWebApi.Bills;
using OrdersWebApi.Bills.Queries;
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
    public async Task RetrieveABillWithAnOrderId() {
        _ordersRepository.GetById(TestDefaultValues.OrderId).Returns(TestDefaultValues.AnOrder);

        var receivedBillResponse = await _handler.Handle(new GetBillByOrderIdQuery(TestDefaultValues.OrderId), default);

        var expectedBillResponse = new ReadBillDto {
            Company = TestDefaultValues.CompanyName,
            CompanyAddress = TestDefaultValues.CompanyAddress,
            Customer = TestDefaultValues.CustomerName,
            CustomerAddress = TestDefaultValues.CustomerAddress,
            Items = new List<BillRow> {
                new() { Concept = "1 x Computer Monitor", Value = 100 }
            },
            Total = 100
        };
        receivedBillResponse.Should().BeEquivalentTo(expectedBillResponse);
    }
}