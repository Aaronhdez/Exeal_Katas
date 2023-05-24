using Newtonsoft.Json;
using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Orders.Controllers.Requests;
using OrdersWebApi.Tests.Orders;
using OrdersWebApi.Tests.Products;
using OrdersWebApi.Tests.Users;

namespace OrdersWebApi.Tests.Acceptance;

public class AddProductsToOrderFeature {
    private IClock? _clock;
    private IGuidGenerator _idGenerator;
    private OrdersApi? _ordersApi;
    private OrdersClient? _ordersClient;
    private ProductsClient _productsClient;
    private UsersClient _usersClient;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _idGenerator = new GuidGenerator();
        _ordersApi = new OrdersApi(_clock, _idGenerator);
        var client = _ordersApi.CreateClient();
        _ordersClient = new OrdersClient(client);
        _productsClient = new ProductsClient(client);
        _usersClient = new UsersClient(client);
    }

    [Test]
    public async Task AddProductsToAnOrder() {
        var orderId = await GivenAStoredOrder();

        var editedOrder = await WhenUserAddsANewProductsToIt(orderId);

        await ThenTheOrderItemsListIsUpdated(editedOrder);
    }

    private async Task<string> GivenAStoredOrder() {
        var vendorId = await _usersClient.PostAnUser(UsersMother.TestCreateVendorRequest());
        var customerId = await _usersClient.PostAnUser(UsersMother.TestCreateCustomerRequest());
        var monitorId = await _productsClient.PostAProduct(ProductsMother.ComputerMonitorCreationRequest());
        var orderRequest = OrdersMother.GivenACreateOrderRequest(vendorId, customerId, new[] { monitorId });
        return await _ordersClient.PostAnOrder(orderRequest);
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
        await Verify(editedOrder).ScrubInlineGuids();
    }
}