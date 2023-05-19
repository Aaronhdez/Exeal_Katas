using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Tests.Orders;
using OrdersWebApi.Tests.Products;

namespace OrdersWebApi.Tests.Acceptance;

public class DisplayOrderFeature {
    private HttpClient _client;
    private IClock? _clock;
    private IGuidGenerator _idGenerator;
    private OrdersApi _ordersApi;
    private OrdersClient _ordersClient;
    private ProductReferenceGenerator _productReferenceGenerator;
    private ProductsClient _productsClient;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _idGenerator = Substitute.For<IGuidGenerator>();
        _idGenerator.NewId().Returns(OrderDefaultValues.OrderGuid);
        _ordersApi = new OrdersApi(_clock, _idGenerator);
        _client = _ordersApi.CreateClient();
        _ordersClient = new OrdersClient(_client);
        _productsClient = new ProductsClient(_client);
    }

    [Test]
    public async Task DisplayBasicInformationOfAnOrder() {
        var productId = await GivenAProductInDatabase();
        var order = OrdersMother.GivenAnOrderRequestWithAProductId(productId);

        var createdOrder = await WhenUserRequestsToCreateIt(order);

        await ThenItIsCreatedProperly(createdOrder);
    }

    private async Task<string> GivenAProductInDatabase() {
        var productCreationRequest = ProductsMother.ComputerMonitorCreationRequest();
        return await _productsClient.PostAProduct(productCreationRequest);
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