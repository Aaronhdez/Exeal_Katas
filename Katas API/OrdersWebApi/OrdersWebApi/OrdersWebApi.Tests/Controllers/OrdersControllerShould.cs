using NSubstitute;
using NSubstitute.ReceivedExtensions;
#pragma warning disable CS8602

namespace OrdersWebApi.Tests.Controllers;

public class OrdersControllerShould
{
    private OrdersController? _ordersController;
    private IClock? _clock;
    private CreateOrderCommand? _createOrderCommand;

    [SetUp]
    public void SetUp()
    {
        _clock = Substitute.For<IClock>();
        _createOrderCommand = Substitute.For<CreateOrderCommand>();
        _ordersController = new OrdersController(_clock, _createOrderCommand);   
    }

    [Test]
    public async Task PostAnOrderWithoutProductsSuccess()
    {
        _clock.Timestamp().Returns(new DateTime(2023, 04, 24));
        
        var createOrderRequest = new CreateOrderRequest("John Doe", "A Simple Street, 123", new Product[]{});
        await _ordersController.Post("ORD123456", createOrderRequest);
        
        var expectedCreateOrderDto = new CreateOrderDto("ORD123456", new DateTime(2023,04,24),"John Doe", "A Simple Street, 123", new Product[]{});
        _createOrderCommand.Received().Execute(expectedCreateOrderDto);
    }
}