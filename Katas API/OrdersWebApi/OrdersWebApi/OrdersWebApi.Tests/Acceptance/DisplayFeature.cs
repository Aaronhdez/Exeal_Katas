using System.Text;
using Newtonsoft.Json;
using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Tests.Orders.Repositories;

namespace OrdersWebApi.Tests.Acceptance;

public class DisplayFeature {
    private const string OrderId = "ORD123458";
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
        var order = GivenAnOrderToBeCreated(OrderId);
        
        var createdOrder = await WhenUserRequestsToCreateIt(order, OrderId);
        
        await ThenItIsCreatedProperly(createdOrder);
    }

    private static string GivenAnOrderToBeCreated(string orderId) {
        return JsonConvert.SerializeObject(new {
            id = orderId,
            customer = "John Doe",
            address = "A Simple Address, 123",
            products = new List<Item>() {
                new("PROD000001", "Computer Monitor", 100),
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