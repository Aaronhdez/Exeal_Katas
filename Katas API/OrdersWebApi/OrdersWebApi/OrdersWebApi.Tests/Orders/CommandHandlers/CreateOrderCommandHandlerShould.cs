using NSubstitute;
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
        _clock.Timestamp().Returns(new DateTime(2023, 04, 24));
        _createOrderCommandHandler = new CreateOrderCommandHandler(_orderRepository, _clock);
    }

    [Test]
    public async Task CreateANewOrderWithoutProducts() {
        var createOrderCommand = new CreateOrderCommand(
            "ORD123456", new CreateOrderDto("John Doe", "A Simple Street, 123", new Product[] { }));

        await _createOrderCommandHandler.Handle(createOrderCommand, default);

        var expectedOrderModel = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new Products(new List<Product>()));

        _orderRepository.Received().Create(expectedOrderModel);
    }

    [Test]
    public async Task CreateANewOrderWithProductList() {
        var createOrderCommand = new CreateOrderCommand("ORD123456", new CreateOrderDto("John Doe",
            "A Simple Street, 123", new Product[] { new("PROD000001", "computerMonitor", 70) }));

        await _createOrderCommandHandler.Handle(createOrderCommand, default);

        var expectedOrderModel = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new Products(new List<Product> { new("PROD000001", "computerMonitor", 70) }));

        _orderRepository.Received(1).Create(expectedOrderModel);
    }
}