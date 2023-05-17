using Newtonsoft.Json;
using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Products;
using OrdersWebApi.Products.Controllers.Requests;

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
        var createProductRequest = GivenAProductCreationRequest();
        
        var id = await WhenUserRequestsToCreateIt(createProductRequest);
        
        await ThenTheProductIsCreatedProperly(id);
    }

    private string GivenAProductCreationRequest() {
        var productCreationRequest = new CreateProductRequest {
            Type = "MON",
            Name = "Computer Monitor",
            Description = "A description",
            Manufacturer ="A Manufacturer",
            ManufacturerReference = "A Reference",
            Value = 100};
        return JsonConvert.SerializeObject(productCreationRequest);
    }

    private async Task<string> WhenUserRequestsToCreateIt(string createProductDto) {
        return await _productsClient.PostAProduct(_ordersApi.CreateClient(), createProductDto);
    }

    private async Task ThenTheProductIsCreatedProperly(string id) {
        var json = await _productsClient.GetAProductById(_ordersApi.CreateClient(), id);
        Verify(json);
    }
}