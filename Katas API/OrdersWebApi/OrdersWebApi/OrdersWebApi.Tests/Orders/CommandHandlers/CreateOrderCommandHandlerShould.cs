using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Commands;
using OrdersWebApi.Orders.Commands.Dto;

namespace OrdersWebApi.Tests.Orders.Commands;

public class CreateOrderCommandHandlerShould
{
    private CreateOrderCommand _createOrderCommand;
    private IOrderRepository _orderRepository;
    private CreateOrderCommandHandler _createOrderCommandHandler;
    private IClock _clock;

    [SetUp]
    public void SetUp()
    {
        _orderRepository = Substitute.For<IOrderRepository>();
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(new DateTime(2023, 04, 24));
        _createOrderCommandHandler = new CreateOrderCommandHandler(_orderRepository, _clock);
    }

    [Test]
    public async Task CreateANewOrderWithoutProductsSuccess()
    {
        var createOrderCommand = new CreateOrderCommand(
            "ORD123456", new CreateOrderDto("John Doe", "A Simple Street, 123", new Product[] { }));

        await _createOrderCommandHandler.Handle(createOrderCommand, default);

        var expectedOrderModel = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new Products(new List<Product>()));

        _orderRepository.Received().Create(expectedOrderModel);
    }

    [Test]
    public async Task CreateANewOrderWithProductListSuccess()
    {
        var createOrderCommand = new CreateOrderCommand("ORD123456", new CreateOrderDto("John Doe",
            "A Simple Street, 123", new Product[] { new("computerMonitor", 70) }));

        await _createOrderCommandHandler.Handle(createOrderCommand, default);

        var expectedOrderModel = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new Products(new List<Product> { new("computerMonitor", 70) }));
        
        _orderRepository.Received(1).Create(expectedOrderModel);
    }
}