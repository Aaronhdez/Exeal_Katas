using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Products;
using OrdersWebApi.Tests.Products;
using OrdersWebApi.Tests.Products.Repositories;

namespace OrdersWebApi.Tests.Acceptance;

public class DisplayProductFeature {
    private IClock? _clock;
    private OrdersApi _ordersApi;
    private IGuidGenerator _idGenerator;
    private ProductsClient _productsClient;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _idGenerator = Substitute.For<IGuidGenerator>();
        _idGenerator.NewId().Returns(TestDefaultValues.OrderGuid);
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
        Verify(await _productsClient.GetAProductById(id));
    }
}