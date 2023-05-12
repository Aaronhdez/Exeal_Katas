using Newtonsoft.Json;
using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Tests.Orders;

namespace OrdersWebApi.Tests.Acceptance;

public class AddProductsToOrderFeature {
    private IClock? _clock;
    private OrdersApi? _ordersApi;
    private OrdersClient? _ordersClient;
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
    public async Task AddProductsToAnOrder() {
        await GivenAStoredOrder();

        var editedOrder = await WhenUserAddsANewProductsToIt(TestDefaultValues.OrderId);

        await ThenTheOrderItemsListIsUpdated(editedOrder);
    }

    private async Task GivenAStoredOrder() {
        var order = JsonConvert.SerializeObject(new {
            id = TestDefaultValues.OrderId,
            customer = TestDefaultValues.CustomerName,
            address = TestDefaultValues.CustomerAddress,
            products = new List<Item> {
                TestDefaultValues.ComputerMonitor
            }
        });
        await _ordersClient.PostAnOrder(order);
    }

    private async Task<string> WhenUserAddsANewProductsToIt(string orderId) {
        var addedItems = OrdersClient.GenerateAListOfProducts(new List<Item> {
            TestDefaultValues.Keyboard,
            TestDefaultValues.Mouse
        });
        await _ordersClient.PutAnOrder(orderId, addedItems);
        var editedOrder = await _ordersClient.GetAnOrder(orderId);
        return editedOrder;
    }

    private static async Task ThenTheOrderItemsListIsUpdated(string editedOrder) {
        await Verify(editedOrder);
    }
}