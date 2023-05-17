using System.Text;
using Newtonsoft.Json;

namespace OrdersWebApi.Tests.Acceptance;

public class ProductsClient {
    private readonly HttpClient _client;

    public ProductsClient(HttpClient client) {
        _client = client;
    }

    public async Task<string> PostAProduct(HttpClient httpClient, string createProductDto) {
        var postResponse = await _client.PostAsync("/Products",
            new StringContent(createProductDto, Encoding.Default, "application/json"));
        postResponse.EnsureSuccessStatusCode();
        var content = await postResponse.Content.ReadAsStringAsync();
        return content;
    }

    public async Task<string> GetAProductById(HttpClient httpClient, string id) {
        var getResponse = await _client.GetAsync($"/Products/{id}");
        getResponse.EnsureSuccessStatusCode();
        var content = await getResponse.Content.ReadAsStringAsync();
        var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);
        return json;
    }
}