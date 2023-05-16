using Newtonsoft.Json;
using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Orders;
using OrdersWebApi.Tests.Bills;
using OrdersWebApi.Tests.Orders;

namespace OrdersWebApi.Tests.Acceptance;

public class GettingABillOfAnOrderFeature {
    private BillsClient _billsClient;
    private IClock _clock;
    private OrdersClient _ordersClient;
    private HttpClient _client;
    private IGuidGenerator _idGenerator;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _idGenerator = Substitute.For<IGuidGenerator>();
        _idGenerator.NewId().Returns(TestDefaultValues.OrderGuid);
        _client = new OrdersApi(_clock, _idGenerator).CreateClient();
        _ordersClient = new OrdersClient(_client);
        _billsClient = new BillsClient(_client);
    }

    [Test]
    public async Task GetABillForAnOrderStored() {
        var orderId = await GivenAStoredOrder();
    
        var bill = await WhenUserRequestsItsBill(orderId);
    
        await ThenItIsRetrievedProperly(bill);
    }
    
    private async Task<string> GivenAStoredOrder() {
        var order = JsonConvert.SerializeObject(new {
            id = TestDefaultValues.OrderId,
            customer = TestDefaultValues.CustomerName,
            address = TestDefaultValues.CustomerAddress,
            products = new List<Product> {
                TestDefaultValues.ComputerMonitor,
                TestDefaultValues.ComputerMonitor,
                TestDefaultValues.Keyboard,
                TestDefaultValues.Keyboard,
                TestDefaultValues.Mouse
            }
        });
        return await _ordersClient.PostAnOrder(order);
    }

    private async Task<string> WhenUserRequestsItsBill(string orderId) {
        var bill = await _billsClient.GetOrderBillById(orderId);
        return bill;
    }

    private async Task ThenItIsRetrievedProperly(string bill) {
        await Verify(bill);
    }
}