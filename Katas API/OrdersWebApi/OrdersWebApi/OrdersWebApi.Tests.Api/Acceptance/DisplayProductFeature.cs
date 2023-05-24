using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Tests.Orders;
using OrdersWebApi.Tests.Products;
using OrdersWebApi.TestUtils;
using OrdersWebApi.TestUtils.Orders;
using OrdersWebApi.TestUtils.Products;

namespace OrdersWebApi.Tests.Acceptance;

public class DisplayProductFeature {
    private IClock? _clock;
    private IGuidGenerator _idGenerator;
    private OrdersApi _ordersApi;
    private ProductsClient _productsClient;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _idGenerator = Substitute.For<IGuidGenerator>();
        _idGenerator.NewId().Returns(OrderDefaultValues.OrderGuid);
        _ordersApi = new OrdersApi(_clock, _idGenerator);
        _productsClient = new ProductsClient(_ordersApi.CreateClient());
    }

    [Test]
    public async Task DisplayACreatedProduct() {
        var createProductRequest = GivenAStoredProduct();

        var id = await WhenUserRequestsToCreateIt(createProductRequest);

        await ThenTheProductIsCreatedProperly(id);
    }

    private static string GivenAStoredProduct() {
        return ProductsMother.ComputerMonitorCreationRequest();
    }

    private async Task<string> WhenUserRequestsToCreateIt(string createProductDto) {
        return await _productsClient.PostAProduct(createProductDto);
    }

    private async Task ThenTheProductIsCreatedProperly(string id) {
        await Verify(await _productsClient.GetAProductById(id));
    }
}