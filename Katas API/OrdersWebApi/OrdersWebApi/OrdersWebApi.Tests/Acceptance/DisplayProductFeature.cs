using System.Text;
using Newtonsoft.Json;
using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Products;
using OrdersWebApi.Tests.Orders;

namespace OrdersWebApi.Tests.Acceptance;

public class DisplayProductFeature {
    private IClock? _clock;
    private OrdersApi _ordersApi;
    private IGuidGenerator _idGenerator;
    private HttpClient _client;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _idGenerator = Substitute.For<IGuidGenerator>();
        _idGenerator.NewId().Returns(TestDefaultValues.OrderGuid);
        _ordersApi = new OrdersApi(_clock, _idGenerator);
        _client = _ordersApi.CreateClient();
    }

    [Test]
    public async Task DisplayACreatedProduct() {
        var createProductDto = GivenAProductCreationDto();
        
        var id = await WhenUserRequestsToCreateIt(createProductDto);
        
        await ThenTheProductIsCreatedProperly(id);
    }

    private string GivenAProductCreationDto() {
        var productCreationDto = new CreateProductDto("MON",
            "Computer Monitor",
            "A description",
            "A Manufacturer",
            "A Reference",
            100);
        return JsonConvert.SerializeObject(productCreationDto);
    }

    private async Task<string> WhenUserRequestsToCreateIt(string createProductDto) {
        var postResponse = await _client.PostAsync("/Products", new StringContent(createProductDto, Encoding.Default, "application/json"));
        postResponse.EnsureSuccessStatusCode();
        var content = await postResponse.Content.ReadAsStringAsync();
        return content;
    }

    private async Task ThenTheProductIsCreatedProperly(string id) {
        var getResponse = await _client.GetAsync($"/Products/{id}");
        getResponse.EnsureSuccessStatusCode();
        var content = await getResponse.Content.ReadAsStringAsync();
        var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);
        Verify(json);
    }
}