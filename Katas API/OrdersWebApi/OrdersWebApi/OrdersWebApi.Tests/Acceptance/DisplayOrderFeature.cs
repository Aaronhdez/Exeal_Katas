using Newtonsoft.Json;
using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Controllers.Requests;
using OrdersWebApi.Products;
using OrdersWebApi.Products.Controllers.Requests;
using OrdersWebApi.Tests.Orders;
using OrdersWebApi.Tests.Products;
using OrdersWebApi.Tests.Products.Repositories;

namespace OrdersWebApi.Tests.Acceptance;

public class DisplayOrderFeature {
    private IClock? _clock;
    private OrdersApi _ordersApi;
    private OrdersClient _ordersClient;
    private IGuidGenerator _idGenerator;
    private ProductsClient _productsClient;
    private ProductReferenceGenerator _productReferenceGenerator;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _idGenerator = Substitute.For<IGuidGenerator>();
        _idGenerator.NewId().Returns(TestDefaultValues.OrderGuid);
        _ordersApi = new OrdersApi(_clock, _idGenerator);
        var client = _ordersApi.CreateClient();
        _ordersClient = new OrdersClient(client);
        _productsClient = new ProductsClient(client);
    }

    [Test]
    public async Task DisplayBasicInformationOfAnOrder() {
        var productId = await GivenAProductInDatabase();
        var order = OrdersObjectMother.GivenAnOrderRequestWithAProductId(productId);

        var createdOrder = await WhenUserRequestsToCreateIt(order);

        await ThenItIsCreatedProperly(createdOrder);
    }

    private async Task<string> WhenUserRequestsToCreateIt(string order) {
        var orderId = await _ordersClient.PostAnOrder(order);
        var createdOrder = await _ordersClient.GetAnOrder(orderId);
        return createdOrder;
    }

    private static async Task ThenItIsCreatedProperly(string createdOrder) {
        await Verify(createdOrder);
    }

    private async Task<string> GivenAProductInDatabase() {
        var productCreationRequest = ProductsObjectMother.ComputerMonitorCreationRequest();
        return await _productsClient.PostAProduct(productCreationRequest);
    }
}