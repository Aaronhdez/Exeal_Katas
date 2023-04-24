using NSubstitute;

namespace OrdersWebApi.Tests.Commands;

public class CreateOrderCommandShould
{
    private CreateOrderCommand _createOrderCommand;
    private IOrderRepository _orderRepository;

    [SetUp]
    public void SetUp()
    {
        _orderRepository = Substitute.For<IOrderRepository>();
        _createOrderCommand = new CreateOrderCommand(_orderRepository);
    }

    [Test]
    public void CreateANewOrder()
    {
        var givenCreateOrderDto = new CreateOrderDto("ORD123456", new DateTime(2023, 04, 24), "John Doe",
            "A Simple Street, 123", new Product[] { });
        
        _createOrderCommand.Execute(givenCreateOrderDto);
        
        var expectedCreateOrderModelDto = new CreateOrderModelDto("ORD123456", "24/04/2023", "John Doe",
            "A Simple Street, 123", new Product[] { });
        _orderRepository.Received().Create(expectedCreateOrderModelDto);
    }
}
