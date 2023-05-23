using System.Text;
using Newtonsoft.Json;
using OrdersWebApi.Tests.Acceptance;

namespace OrdersWebApi.Tests.Users;

public class UsersClient {
    private HttpClient _client;
    public UsersClient(HttpClient client) {
        _client = client;
    }

    public async Task<string> PostAnUser(string createUserRequest) {
        var postResponse = await _client.PostAsync("/Users",
            new StringContent(createUserRequest, Encoding.Default, "application/json"));
        postResponse.EnsureSuccessStatusCode();
        return await postResponse.Content.ReadAsStringAsync();
    }

    public async Task<string> GetAnUserById(string userId, CreateUsersFeature createUsersFeature) {
        var getResponse = await _client.GetAsync($"/Users/{userId}");
        getResponse.EnsureSuccessStatusCode();
        var content = await getResponse.Content.ReadAsStringAsync();
        var createdUser = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);
        return createdUser;
    }
}