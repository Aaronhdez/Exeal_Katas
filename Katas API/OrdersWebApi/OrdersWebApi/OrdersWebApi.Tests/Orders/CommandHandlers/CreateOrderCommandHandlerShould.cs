using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Commands.CreateOrder;
using OrdersWebApi.Products;

namespace OrdersWebApi.Tests.Orders.CommandHandlers;

public class CreateOrderCommandHandlerShould {
    private IClock _clock;
    private CreateOrderCommand _createOrderCommand;
    private CreateOrderCommandHandler _createOrderCommandHandler;
    private IOrderRepository _orderRepository;
    private IProductsRepository _productsRepository;

    [SetUp]
    public void SetUp() {
        _orderRepository = Substitute.For<IOrderRepository>();
        _productsRepository = Substitute.For<IProductsRepository>();
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _createOrderCommandHandler = new CreateOrderCommandHandler(_orderRepository, _productsRepository, _clock);
    }

    [Test]
    public async Task CreateANewOrderWithoutProducts() {
        var createOrderCommand = new CreateOrderCommand(new CreateOrderDto(
            TestDefaultValues.OrderId, 
            TestDefaultValues.CustomerName, 
            TestDefaultValues.CustomerAddress, 
            Array.Empty<string>()));

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
        _productsRepository.GetById(TestDefaultValues.ComputerMonitorId).Returns(TestDefaultValues.ComputerMonitor);
        var createOrderCommand = new CreateOrderCommand(new CreateOrderDto(
            TestDefaultValues.OrderId,
            TestDefaultValues.CustomerName,
            TestDefaultValues.CustomerAddress,
            new[] {
                TestDefaultValues.ComputerMonitorId
            }));

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