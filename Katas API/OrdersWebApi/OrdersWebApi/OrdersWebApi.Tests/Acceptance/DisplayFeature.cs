using System.Text;
using Newtonsoft.Json;

namespace OrdersWebApi.Tests.Acceptance;

public class DisplayFeature
{
    [Test]
    public async Task DisplayBasicInformationOfAnOrder()
    {
        var socialNetworkApp = new OrdersApi();
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