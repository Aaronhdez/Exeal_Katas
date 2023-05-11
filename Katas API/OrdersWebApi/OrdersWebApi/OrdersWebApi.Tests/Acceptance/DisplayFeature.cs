using Newtonsoft.Json;
using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Tests.Orders;

namespace OrdersWebApi.Tests.Acceptance;

public class DisplayFeature {
    private IClock? _clock;
    private OrdersApi _ordersApi;
    private OrdersClient _ordersClient;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _ordersApi = new OrdersApi(_clock);
        _ordersClient = new OrdersClient(_ordersApi.CreateClient());
    }

    [Test]
    public async Task DisplayBasicInformationOfAnOrder() {
        var order = GivenAnOrderToBeCreated();

        var createdOrder = await WhenUserRequestsToCreateIt(order);

        await ThenItIsCreatedProperly(createdOrder);
    }

    private static string GivenAnOrderToBeCreated() {
        return JsonConvert.SerializeObject(new {
            id = TestDefaultValues.OrderId,
            customer = TestDefaultValues.CustomerName,
            address = TestDefaultValues.CustomerAddress,
            products = new List<Item> {
                TestDefaultValues.ComputerMonitor
            }
        });
    }

    private async Task<string> WhenUserRequestsToCreateIt(string order) {
        var orderId = await _ordersClient.PostAnOrder(order);
        var createdOrder = await _ordersClient.GetAnOrder(orderId);
        return createdOrder;
    }

    private static async Task ThenItIsCreatedProperly(string createdOrder) {
        await Verify(createdOrder);
    }
}