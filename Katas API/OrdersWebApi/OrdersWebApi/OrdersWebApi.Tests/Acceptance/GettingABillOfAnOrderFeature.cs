using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Orders;
using OrdersWebApi.Products;
using OrdersWebApi.Tests.Bills;
using OrdersWebApi.Tests.Orders;
using OrdersWebApi.Tests.Products;

namespace OrdersWebApi.Tests.Acceptance;

public class GettingABillOfAnOrderFeature {
    private BillsClient _billsClient;
    private IClock _clock;
    private OrdersClient _ordersClient;
    private HttpClient _client;
    private IGuidGenerator _idGenerator;
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
        var computerId = await _productsClient.PostAProduct(ProductsObjectMother.ComputerMonitorCreationRequest());
        var keyboardId = await _productsClient.PostAProduct(ProductsObjectMother.KeyboardCreationRequest());
        var mouseId = await _productsClient.PostAProduct(ProductsObjectMother.MouseCreationRequest());
        return await _ordersClient.PostAnOrder(OrdersObjectMother.GivenAnOrderRequestWithProductsAssigned(
            new[] { computerId, computerId, keyboardId, keyboardId, mouseId }));
    }

    private async Task<string> WhenUserRequestsItsBill(string orderId) {
        return await _billsClient.GetOrderBillById(orderId);
    }

    private async Task ThenItIsRetrievedProperly(string bill) {
        await Verify(bill);
    }
}