using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Commands.CreateOrder;
using OrdersWebApi.Tests.Acceptance;

namespace OrdersWebApi.Tests.Orders.CommandHandlers;

public class CreateOrderCommandHandlerShould {
    private IClock _clock;
    private CreateOrderCommand _createOrderCommand;
    private CreateOrderCommandHandler _createOrderCommandHandler;
    private IOrderRepository _orderRepository;

    [SetUp]
    public void SetUp() {
        _orderRepository = Substitute.For<IOrderRepository>();
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _createOrderCommandHandler = new CreateOrderCommandHandler(_orderRepository, _clock);
    }

    [Test]
    public async Task CreateANewOrderWithoutProducts() {
        var createOrderCommand = new CreateOrderCommand(
            TestDefaultValues.OrderId, new CreateOrderDto(TestDefaultValues.CustomerName, "A Simple Street, 123", new Item[] { }));

        await _createOrderCommandHandler.Handle(createOrderCommand, default);

        var expectedOrderModel = new Order(TestDefaultValues.OrderId, TestDefaultValues.CreationDate, TestDefaultValues.CustomerName, "A Simple Street, 123",
            new List<Item>());

        _orderRepository.Received().Create(expectedOrderModel);
    }

    [Test]
    public async Task CreateANewOrderWithProductList() {
        var createOrderCommand = new CreateOrderCommand(TestDefaultValues.OrderId, new CreateOrderDto(TestDefaultValues.CustomerName,
            "A Simple Street, 123", new Item[] { new(TestDefaultValues.ComputerMonitorId, "computerMonitor", 70) }));

        await _createOrderCommandHandler.Handle(createOrderCommand, default);

        var expectedOrderModel = new Order(TestDefaultValues.OrderId, TestDefaultValues.CreationDate, TestDefaultValues.CustomerName, "A Simple Street, 123",
            new List<Item> { new(TestDefaultValues.ComputerMonitorId, "computerMonitor", 70) });

        _orderRepository.Received(1).Create(expectedOrderModel);
    }
}