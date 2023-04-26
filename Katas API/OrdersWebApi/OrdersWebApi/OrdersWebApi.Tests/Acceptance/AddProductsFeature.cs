using System.Text;
using Newtonsoft.Json;
using NSubstitute;

namespace OrdersWebApi.Tests.Acceptance;

public class AddProductsFeature
{
    [Test]
    public async Task AddProductsToAnOrder()
    {
        var clock = Substitute.For<IClock>();
        clock.Timestamp().Returns(new DateTime(2023, 04, 24));
        var ordersApi = new OrdersApi(clock);
        var client = ordersApi.CreateClient();
        var order = "{" +
                    "\"id\": \"ORD123456\"," +
                    "\"customer\": \"John Doe\"," +
                    "\"address\": \"A Simple Address, 123\"," +
                    "\"products\": [" +
                    "{" +
                    "\"name\": \"Computer Monitor\"," +
                    "\"value\": 100" +
                    "}" +
                    "]" +
                    "}";

        string newProducts = "{[" +
                             "{" +
                             "\"name\": \"Keyboard\"," +
                             "\"value\": 20" +
                             "}," +
                             "{" +
                             "\"name\": \"Mouse\"," +
                             "\"value\": 15" +
                             "}" +
                             "]}";

        var postResponse =
            await client.PostAsync("/Orders", new StringContent(order, Encoding.Default, "application/json"));
        postResponse.EnsureSuccessStatusCode();
        var getResponse = await client.GetAsync("/Orders/ORD123456");
        getResponse.EnsureSuccessStatusCode();
        var putResponse = await client.PutAsync("/Orders/ORD123456/Products",
            new StringContent(newProducts, Encoding.Default, "application/json"));
        putResponse.EnsureSuccessStatusCode();
        getResponse = await client.GetAsync("/Orders/ORD123456");
        getResponse.EnsureSuccessStatusCode();

        var content = await getResponse.Content.ReadAsStringAsync();
        var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);

        await Verifier.Verify(json);
    }
}