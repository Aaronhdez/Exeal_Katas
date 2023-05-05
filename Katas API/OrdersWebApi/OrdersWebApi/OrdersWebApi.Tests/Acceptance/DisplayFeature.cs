using System.Text;
using Newtonsoft.Json;
using NSubstitute;

namespace OrdersWebApi.Tests.Acceptance;

public class DisplayFeature {
    [Test]
    public async Task DisplayBasicInformationOfAnOrder() {
        var clock = Substitute.For<IClock>();
        clock.Timestamp().Returns(new DateTime(2023, 04, 24));
        var ordersApi = new OrdersApi(clock);
        var client = ordersApi.CreateClient();
        var jsonstring = "{" +
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

        var postResponse = await client.PostAsync("/Orders",
            new StringContent(jsonstring, Encoding.Default, "application/json"));
        postResponse.EnsureSuccessStatusCode();
        var getResponse = await client.GetAsync("/Orders/ORD123456");
        getResponse.EnsureSuccessStatusCode();

        var content = await getResponse.Content.ReadAsStringAsync();
        var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);

        await Verify(json);
    }
}