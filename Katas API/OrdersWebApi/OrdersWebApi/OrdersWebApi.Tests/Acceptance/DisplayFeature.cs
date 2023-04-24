using System.Text;
using Newtonsoft.Json;
using NSubstitute;

namespace OrdersWebApi.Tests.Acceptance;

public class DisplayFeature
{
    [Test]
    public async Task DisplayBasicInformationOfAnOrder()
    {
        var clock = Substitute.For<IClock>();
        clock.Timestamp().Returns(new DateTime(2023, 04, 24));
        var socialNetworkApp = new OrdersApi(clock);
        var client = socialNetworkApp.CreateClient();
        var jsonPost = "{\"id\": \"ORD123456\"," +
                            "\"customer\": \"John Doe\"," +
                            "\"address\": \"A Simple Street, 123\","  +
                            "\"products\": [" +
                              "\"product\":" +
                                "\"name\": \"Computer Monitor\"," +
                                "\"price\": \"100€\"" +
                              "\"product\":" +
                                "\"name\": \"Keyboard\"," + 
                                "\"price\": \"30€\"" +
                            "]}";

        var postResponse = await client.PostAsync("/Orders/ORD123456", new StringContent(jsonPost, Encoding.Default, "application/json"));
        postResponse.EnsureSuccessStatusCode();
        var response = await client.GetAsync("/Orders/ORD123456");
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);
        
        await Verifier.Verify(json);
    }
}