using System.Text;
using Newtonsoft.Json;
using OrdersWebApi.Orders;

namespace OrdersWebApi.Tests.Acceptance;

public class OrdersClient {
    private readonly HttpClient _client;

    public OrdersClient(HttpClient client) {
        _client = client;
    }

    public static string GenerateAListOfProducts(List<Item> items) {
        var newProducts = JsonConvert.SerializeObject(new {
            products = items
        });
        return newProducts;
    }

    public async Task PutAnOrder(string orderId, string addedItems) {
        var putResponse = await _client.PutAsync($"/Orders/{orderId}/Products",
            new StringContent(addedItems, Encoding.Default, "application/json"));
        putResponse.EnsureSuccessStatusCode();
    }

    public async Task<string> GetAnOrder(string orderId) {
        var getResponse = await _client.GetAsync($"/Orders/{orderId}");
        getResponse.EnsureSuccessStatusCode();
        var content = await getResponse.Content.ReadAsStringAsync();
        return JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);
    }

    public async Task PostAnOrder(string order) {
        var postResponse =
            await _client.PostAsync("/Orders", new StringContent(order, Encoding.Default, "application/json"));
        postResponse.EnsureSuccessStatusCode();
    }
}