using Newtonsoft.Json;
using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Tests.Orders;
using OrdersWebApi.Tests.Users;

namespace OrdersWebApi.Tests.Acceptance;

public class CreateUsersFeature {
    private IClock? _clock;
    private IGuidGenerator _idGenerator;
    private OrdersApi _ordersApi;
    private UsersClient _client;

    [SetUp]
    public void SetUp() {
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _idGenerator = Substitute.For<IGuidGenerator>();
        _idGenerator.NewId().Returns(OrderDefaultValues.OrderGuid);
        _ordersApi = new OrdersApi(_clock, _idGenerator);
        _client = new UsersClient(_ordersApi.CreateClient());
    }

    [Test]
    public async Task DisplayProperInformationOfACreatedUser() {
        var createUserRequest = GivenAUserCreationRequest();
        var userId = await WhenItIsCreated(createUserRequest);
        ItIsDisplayedProperly(userId);
    }

    private string GivenAUserCreationRequest() {
        return JsonConvert.SerializeObject(UsersMother.TestCreateUserRequest());
    }

    private async Task<string> WhenItIsCreated(string createUserRequest) {
        return await _client.PostAnUser(createUserRequest);
    }

    private async void ItIsDisplayedProperly(string userId) {
        var createdUser = await _client.GetAnUserById(userId, this);
        Verify(createdUser);
    }
}