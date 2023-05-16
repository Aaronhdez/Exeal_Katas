using Newtonsoft.Json;
using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Orders;
using OrdersWebApi.Tests.Orders;

namespace OrdersWebApi.Tests.Acceptance;

public class DisplayOrderFeature {
    private IClock? _clock;
    private OrdersApi _ordersApi;
    private OrdersClient _ordersClient;
    private IGuidGenerator _idGenerator;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _idGenerator = Substitute.For<IGuidGenerator>();
        _idGenerator.NewId().Returns(TestDefaultValues.OrderGuid);
        _ordersApi = new OrdersApi(_clock, _idGenerator);
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
            products = new List<Product> {
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