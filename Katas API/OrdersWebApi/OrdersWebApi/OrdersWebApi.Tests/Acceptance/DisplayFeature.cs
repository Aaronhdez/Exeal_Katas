using Newtonsoft.Json;
using NSubstitute;
using OrdersWebApi.Orders;

namespace OrdersWebApi.Tests.Acceptance;

public class DisplayFeature {
    private IClock? _clock;
    private OrdersApi _ordersApi;
    private OrdersClient _ordersClient;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(new DateTime(2023, 04, 24));
        _ordersApi = new OrdersApi(_clock);
        _ordersClient = new OrdersClient(_ordersApi.CreateClient());
    }

    [Test]
    public async Task DisplayBasicInformationOfAnOrder() {
        var order = GivenAnOrderToBeCreated(TestDefaultValues.OrderId);

        var createdOrder = await WhenUserRequestsToCreateIt(order, TestDefaultValues.OrderId);

        await ThenItIsCreatedProperly(createdOrder);
    }

    private static string GivenAnOrderToBeCreated(string orderId) {
        return JsonConvert.SerializeObject(new {
            id = TestDefaultValues.OrderId,
            customer = TestDefaultValues.CustomerName,
            address = TestDefaultValues.CustomerAddress,
            products = new List<Item> {
                TestDefaultValues.ComputerMonitor
            }
        });
    }

    private async Task<string> WhenUserRequestsToCreateIt(string order2, string orderId) {
        await _ordersClient.PostAnOrder(order2);
        var createdOrder = await _ordersClient.GetAnOrder(orderId);
        return createdOrder;
    }

    private static async Task ThenItIsCreatedProperly(string createdOrder) {
        await Verify(createdOrder);
    }
}