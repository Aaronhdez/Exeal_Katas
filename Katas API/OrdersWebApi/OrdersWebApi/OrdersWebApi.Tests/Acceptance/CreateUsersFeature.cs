using System.Text;
using Newtonsoft.Json;
using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Tests.Orders;
using OrdersWebApi.Users.Controllers;

namespace OrdersWebApi.Tests.Acceptance;

public class CreateUsersFeature {
    private HttpClient _client;
    private IClock? _clock;
    private IGuidGenerator _idGenerator;
    private OrdersApi _ordersApi;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _idGenerator = Substitute.For<IGuidGenerator>();
        _idGenerator.NewId().Returns(OrderDefaultValues.OrderGuid);
        _ordersApi = new OrdersApi(_clock, _idGenerator);
        _client = _ordersApi.CreateClient();
    }

    [Test]
    public async Task DisplayProperInformationOfACreatedUser() {
        var createUserRequest = GivenAUserCreationRequest();
        var userId = await WhenItIsCreated(createUserRequest);
        ItIsDisplayedProperly(userId);
    }

    private string GivenAUserCreationRequest() {
        return JsonConvert.SerializeObject(new CreateUserRequest(string.Empty, string.Empty));
    }

    private async Task<string> WhenItIsCreated(string createUserRequest) {
        var postResponse = await _client.PostAsync("/Users",
            new StringContent(createUserRequest, Encoding.Default, "application/json"));
        postResponse.EnsureSuccessStatusCode();
        return await postResponse.Content.ReadAsStringAsync();
    }

    private async void ItIsDisplayedProperly(string userId) {
        var getResponse = await _client.GetAsync($"/Users/{userId}");
        getResponse.EnsureSuccessStatusCode();
        var content = await getResponse.Content.ReadAsStringAsync();
        var createdUser = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);
        Verify(createdUser);
    }
}