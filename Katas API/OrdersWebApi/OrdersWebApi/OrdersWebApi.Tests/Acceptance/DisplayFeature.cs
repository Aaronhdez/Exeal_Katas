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
        var ordersApi = new OrdersApi(clock);
        var client = ordersApi.CreateClient();
        var jsonstring = "{"+
                                    "\"customer\": \"string\","+
                                    "\"address\": \"string\","+
                                    "\"products\": ["+
                                    "{"+
                                        "\"name\": \"string\","+
                                        "\"value\": 0"+
                                    "}"+
                                    "]"+
                                "}";
        
        var response = await client.GetAsync("/swagger/index.html");
        response.EnsureSuccessStatusCode();
        
        var postResponse = await client.PostAsync("/Orders/ORD123456", new StringContent(jsonstring, Encoding.Default, "application/json"));
        postResponse.EnsureSuccessStatusCode();
        response = await client.GetAsync("/Orders/ORD123456");
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);
        
        await Verifier.Verify(json);
    }
}