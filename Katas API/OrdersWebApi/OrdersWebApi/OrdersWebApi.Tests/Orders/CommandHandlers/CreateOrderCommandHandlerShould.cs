using Castle.Components.DictionaryAdapter;
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
    private IGuidGenerator _idGenerator;

    [SetUp]
    public void SetUp() {
        _orderRepository = Substitute.For<IOrderRepository>();
        _idGenerator = Substitute.For<IGuidGenerator>();
        _idGenerator.NewId().Returns(TestDefaultValues.OrderGuid);
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _createOrderCommandHandler = new CreateOrderCommandHandler(_orderRepository, _clock, _idGenerator);
    }

    [Test]
    public async Task CreateANewOrderWithoutProducts() {
        var createOrderCommand = new CreateOrderCommand(new CreateOrderDto(
                TestDefaultValues.CustomerName, 
                TestDefaultValues.CustomerAddress, 
                Array.Empty<Item>()));

        await _createOrderCommandHandler.Handle(createOrderCommand, default);

        var expectedOrderModel = new Order(
            TestDefaultValues.OrderId, 
            TestDefaultValues.CreationDate, 
            TestDefaultValues.CustomerName, 
            TestDefaultValues.CustomerAddress,
            new List<Item>());

        await _orderRepository.Received().Create(expectedOrderModel);
    }

    [Test]
    public async Task CreateANewOrderWithProductList() {
        var createOrderCommand = new CreateOrderCommand(new CreateOrderDto(
                TestDefaultValues.CustomerName,
                TestDefaultValues.CustomerAddress, 
                new[] { TestDefaultValues.ComputerMonitor }));

        await _createOrderCommandHandler.Handle(createOrderCommand, default);

        var expectedOrderModel = new Order(
            TestDefaultValues.OrderId, 
            TestDefaultValues.CreationDate, 
            TestDefaultValues.CustomerName, 
            TestDefaultValues.CustomerAddress,
            new List<Item> { TestDefaultValues.ComputerMonitor });

        await _orderRepository.Received(1).Create(expectedOrderModel);
    }
}