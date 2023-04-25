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
                                    "\"id\": \"ORD123456\","+ 
                                    "\"customer\": \"string\","+
                                    "\"address\": \"string\","+
                                    "\"products\": ["+
                                    "{"+
                                        "\"name\": \"string\","+
                                        "\"value\": 0"+
                                    "}"+
                                    "]"+
                                "}";
        
        var postResponse = await client.PostAsync("/Orders", new StringContent(jsonstring, Encoding.Default, "application/json"));
        postResponse.EnsureSuccessStatusCode();
        var response = await client.GetAsync("/Orders/ORD123456");
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);
        
        await Verifier.Verify(json);
    }
}