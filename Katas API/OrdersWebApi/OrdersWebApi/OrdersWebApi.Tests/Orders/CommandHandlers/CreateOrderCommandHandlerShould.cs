using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Commands.CreateOrder;

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
        var createOrderCommand = new CreateOrderCommand(new CreateOrderDto(TestDefaultValues.OrderId, TestDefaultValues.CustomerName, TestDefaultValues.CustomerAddress, Array.Empty<Product>()));

        await _createOrderCommandHandler.Handle(createOrderCommand, default);

        var expectedOrderModel = new Order(
            TestDefaultValues.OrderId, 
            TestDefaultValues.CreationDate, 
            TestDefaultValues.CustomerName, 
            TestDefaultValues.CustomerAddress,
            new List<Product>());

        await _orderRepository.Received().Create(expectedOrderModel);
    }

    [Test]
    public async Task CreateANewOrderWithProductList() {
        var createOrderCommand = new CreateOrderCommand(new CreateOrderDto(TestDefaultValues.OrderId, TestDefaultValues.CustomerName, TestDefaultValues.CustomerAddress, new[] { TestDefaultValues.ComputerMonitor }));

        await _createOrderCommandHandler.Handle(createOrderCommand, default);

        var expectedOrderModel = new Order(
            TestDefaultValues.OrderId, 
            TestDefaultValues.CreationDate, 
            TestDefaultValues.CustomerName, 
            TestDefaultValues.CustomerAddress,
            new List<Product> { TestDefaultValues.ComputerMonitor });

        await _orderRepository.Received(1).Create(expectedOrderModel);
    }
}