using Newtonsoft.Json;
using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Controllers.Requests;
using OrdersWebApi.Products;
using OrdersWebApi.Tests.Orders;
using OrdersWebApi.Tests.Products;

namespace OrdersWebApi.Tests.Acceptance;

public class AddProductsToOrderFeature {
    private IClock? _clock;
    private OrdersApi? _ordersApi;
    private OrdersClient? _ordersClient;
    private IGuidGenerator _idGenerator;
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
        var monitorId = await _productsClient.PostAProduct(ProductsObjectMother.ComputerMonitorCreationRequest());
        var orderId = await GivenAStoredOrder(new [] { monitorId });

        var editedOrder = await WhenUserAddsANewProductsToIt(orderId);

        await ThenTheOrderItemsListIsUpdated(editedOrder);
    }

    private async Task<string> GivenAStoredOrder(string[] products) {
        var order = OrdersObjectMother.GivenAnOrderRequestWithProductsAssigned(products);
        return await _ordersClient.PostAnOrder(order);
    }

    private async Task<string> WhenUserAddsANewProductsToIt(string orderId) {
        var addedItems = JsonConvert.SerializeObject(new AddProductsRequest( new[] {
            await _productsClient.PostAProduct(ProductsObjectMother.KeyboardCreationRequest()),
            await _productsClient.PostAProduct(ProductsObjectMother.MouseCreationRequest())
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