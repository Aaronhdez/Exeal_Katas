using System.Text;
using Newtonsoft.Json;

namespace OrdersWebApi.TestUtils;

public class ProductsClient {
    private readonly HttpClient _client;

    public ProductsClient(HttpClient client) {
        _client = client;
    }

    public async Task<string> PostAProduct(string createProductDto) {
        var postResponse = await _client.PostAsync("/Products",
            new StringContent(createProductDto, Encoding.Default, "application/json"));
        postResponse.EnsureSuccessStatusCode();
        var content = await postResponse.Content.ReadAsStringAsync();
        return content;
    }

    public async Task<string> GetAProductById(string id) {
        var getResponse = await _client.GetAsync($"/Products/{id}");
        getResponse.EnsureSuccessStatusCode();
        var content = await getResponse.Content.ReadAsStringAsync();
        var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);
        return json;
    }
}