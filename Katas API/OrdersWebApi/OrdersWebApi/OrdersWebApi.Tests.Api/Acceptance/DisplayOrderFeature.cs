using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Tests.Orders;
using OrdersWebApi.Tests.Products;
using OrdersWebApi.Tests.Users;
using OrdersWebApi.TestUtils;
using OrdersWebApi.TestUtils.Orders;
using OrdersWebApi.TestUtils.Products;
using OrdersWebApi.TestUtils.Users;

namespace OrdersWebApi.Tests.Acceptance;

public class DisplayOrderFeature {
    private HttpClient _client;
    private IClock? _clock;
    private IGuidGenerator _idGenerator;
    private OrdersApi _ordersApi;
    private OrdersClient _ordersClient;
    private ProductReferenceGenerator _productReferenceGenerator;
    private ProductsClient _productsClient;
    private UsersClient _usersClient;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _idGenerator = new GuidGenerator();
        _ordersApi = new OrdersApi(_clock, _idGenerator);
        _client = _ordersApi.CreateClient();
        _ordersClient = new OrdersClient(_client);
        _productsClient = new ProductsClient(_client);
        _usersClient = new UsersClient(_client);
    }

    [Test]
    public async Task DisplayBasicInformationOfAnOrder() {
        var orderRequest = await GivenAnOrderRequest();

        var createdOrder = await WhenUserRequestsToCreateIt(orderRequest);

        await ThenItIsCreatedProperly(createdOrder);
    }

    private async Task<string> GivenAnOrderRequest() {
        var vendorId = await _usersClient.PostAnUser(UsersMother.TestCreateVendorRequest());
        var customerId = await _usersClient.PostAnUser(UsersMother.TestCreateCustomerRequest());
        var productId = await _productsClient.PostAProduct(ProductsMother.ComputerMonitorCreationRequest());
        var orderRequest = OrdersMother.GivenACreateOrderRequest(vendorId, customerId, new[] { productId });
        return orderRequest;
    }

    private async Task<string> WhenUserRequestsToCreateIt(string order) {
        var orderId = await _ordersClient.PostAnOrder(order);
        var createdOrder = await _ordersClient.GetAnOrder(orderId);
        return createdOrder;
    }

    private static async Task ThenItIsCreatedProperly(string createdOrder) {
        await Verify(createdOrder).ScrubInlineGuids();
    }
}