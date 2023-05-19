using Newtonsoft.Json;
using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Orders.Controllers.Requests;
using OrdersWebApi.Tests.Orders;
using OrdersWebApi.Tests.Products;

namespace OrdersWebApi.Tests.Acceptance;

public class AddProductsToOrderFeature {
    private IClock? _clock;
    private IGuidGenerator _idGenerator;
    private OrdersApi? _ordersApi;
    private OrdersClient? _ordersClient;
    private ProductsClient _productsClient;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _idGenerator = new GuidGenerator();
        _ordersApi = new OrdersApi(_clock, _idGenerator);
        var client = _ordersApi.CreateClient();
        _ordersClient = new OrdersClient(client);
        _productsClient = new ProductsClient(client);
    }

    [Test]
    public async Task AddProductsToAnOrder() {
        var orderId = await GivenAStoredOrder();

        var editedOrder = await WhenUserAddsANewProductsToIt(orderId);

        await ThenTheOrderItemsListIsUpdated(editedOrder);
    }

    private async Task<string> GivenAStoredOrder() {
        var monitorId = await _productsClient.PostAProduct(
            ProductsMother.ComputerMonitorCreationRequest());
        var order = OrdersMother.GivenAnOrderRequestWithProductsAssigned(new[] { monitorId });
        return await _ordersClient.PostAnOrder(order);
    }

    private async Task<string> WhenUserAddsANewProductsToIt(string orderId) {
        var addedItems = JsonConvert.SerializeObject(new AddProductsRequest(new[] {
            await _productsClient.PostAProduct(ProductsMother.KeyboardCreationRequest()),
            await _productsClient.PostAProduct(ProductsMother.MouseCreationRequest())
        }));
        await _ordersClient.PutAnOrder(orderId, addedItems);
        return await _ordersClient.GetAnOrder(orderId);
    }

    private static async Task ThenTheOrderItemsListIsUpdated(string editedOrder) {
        var settings = new VerifySettings();
        settings.ScrubLinesContaining("\"id\":");
        await Verify(editedOrder, settings);
    }
}