using Newtonsoft.Json;

namespace OrdersWebApi.Tests.Acceptance;

public class BillsClient {
    private readonly HttpClient _client;

    public BillsClient(HttpClient client) {
        _client = client;
    }

    public async Task<string> GetOrderBillById(string orderId) {
        var getResponse = await _client.GetAsync($"/Bills/{orderId}");
        getResponse.EnsureSuccessStatusCode();
        var content = await getResponse.Content.ReadAsStringAsync();
        var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);
        return json;
    }
}