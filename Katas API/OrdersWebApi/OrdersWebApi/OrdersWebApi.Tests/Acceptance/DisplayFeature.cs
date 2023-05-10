using System.Text;
using Newtonsoft.Json;
using NSubstitute;
using OrdersWebApi.Tests.Orders.Repositories;

namespace OrdersWebApi.Tests.Acceptance;

public class DisplayFeature {
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

    [TearDown]
    public void TearDown() {
    }

    [Test]
    public async Task DisplayBasicInformationOfAnOrder() {
        var orderJsonstring = "{" +
                         "\"id\": \"ORD123458\"," +
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

        var postResponse = await _client.PostAsync("/Orders",
            new StringContent(orderJsonstring, Encoding.Default, "application/json"));
        postResponse.EnsureSuccessStatusCode();
        var getResponse = await _client.GetAsync("/Orders/ORD123458");
        getResponse.EnsureSuccessStatusCode();

        var content = await getResponse.Content.ReadAsStringAsync();
        var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);

        await Verify(json);
    }
}