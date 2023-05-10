using System.Text;
using Newtonsoft.Json;
using NSubstitute;

namespace OrdersWebApi.Tests.Acceptance;

public class AddProductsToOrderFeature {
    private IClock? _clock;
    private OrdersApi _ordersApi;
    private HttpClient _client;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(new DateTime(2023, 04, 24));
        _ordersApi = new OrdersApi(_clock);
        _client = _ordersApi.CreateClient();
    }

    [Test]
    public async Task AddProductsToAnOrder() {
        var order = "{" +
                    "\"id\": \"ORD123456\"," +
                    "\"customer\": \"John Doe\"," +
                    "\"address\": \"A Simple Address, 123\"," +
                    "\"products\": [" +
                    "{" +
                    "\"id\": \"PROD000001\"," +
                    "\"name\": \"Computer Monitor\"," +
                    "\"value\": 100" +
                    "}" +
                    "]" +
                    "}";

        var newProducts = "{\"products\" : [" +
                          "{" +
                          "\"id\": \"PROD000002\"," +
                          "\"name\": \"Keyboard\"," +
                          "\"value\": 20" +
                          "}," +
                          "{" +
                          "\"id\": \"PROD000003\"," +
                          "\"name\": \"Mouse\"," +
                          "\"value\": 15" +
                          "}" +
                          "]}";

        var postResponse =
            await _client.PostAsync("/Orders", new StringContent(order, Encoding.Default, "application/json"));
        postResponse.EnsureSuccessStatusCode();
        var getResponse = await _client.GetAsync("/Orders/ORD123456");
        getResponse.EnsureSuccessStatusCode();
        var putResponse = await _client.PutAsync("/Orders/ORD123456/Products",
            new StringContent(newProducts, Encoding.Default, "application/json"));
        putResponse.EnsureSuccessStatusCode();
        getResponse = await _client.GetAsync("/Orders/ORD123456");
        getResponse.EnsureSuccessStatusCode();

        var content = await getResponse.Content.ReadAsStringAsync();
        var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);

        await Verify(json);
    }
}