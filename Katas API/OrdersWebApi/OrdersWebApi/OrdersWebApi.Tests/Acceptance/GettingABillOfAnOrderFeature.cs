using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Tests.Bills;
using OrdersWebApi.Tests.Orders;
using OrdersWebApi.Tests.Products;

namespace OrdersWebApi.Tests.Acceptance;

public class GettingABillOfAnOrderFeature {
    private BillsClient _billsClient;
    private HttpClient _client;
    private IClock _clock;
    private IGuidGenerator _idGenerator;
    private OrdersClient _ordersClient;
    private ProductsClient _productsClient;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _idGenerator = new GuidGenerator();
        _client = new OrdersApi(_clock, _idGenerator).CreateClient();
        _ordersClient = new OrdersClient(_client);
        _productsClient = new ProductsClient(_client);
        _billsClient = new BillsClient(_client);
    }

    [Test]
    public async Task GetABillForAnOrderStored() {
        var orderId = await GivenAStoredOrderWithProductsAssigned();

        var bill = await WhenUserRequestsItsBill(orderId);

        await ThenItIsRetrievedProperly(bill);
    }

    private async Task<string> GivenAStoredOrderWithProductsAssigned() {
        var computerId = await _productsClient.PostAProduct(ProductsMother.ComputerMonitorCreationRequest());
        var keyboardId = await _productsClient.PostAProduct(ProductsMother.KeyboardCreationRequest());
        var mouseId = await _productsClient.PostAProduct(ProductsMother.MouseCreationRequest());
        return await _ordersClient.PostAnOrder(OrdersMother.GivenAnOrderRequestWithProductsAssigned(
            new[] { computerId, computerId, keyboardId, keyboardId, mouseId }));
    }

    private async Task<string> WhenUserRequestsItsBill(string orderId) {
        return await _billsClient.GetOrderBillById(orderId);
    }

    private async Task ThenItIsRetrievedProperly(string bill) {
        await Verify(bill);
    }
}