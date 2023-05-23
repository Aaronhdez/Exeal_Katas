using FluentAssertions;
using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Commands.CreateOrder;
using OrdersWebApi.Orders.Repositories;
using OrdersWebApi.Products;
using OrdersWebApi.Tests.Products;

namespace OrdersWebApi.Tests.Orders.CommandHandlers;

public class CreateOrderCommandHandlerShould {
    private IClock _clock;
    private CreateOrderCommand _createOrderCommand;
    private CreateOrderCommandHandler _createOrderCommandHandler;
    private IOrderRepository _orderRepository;
    private IProductsRepository _productsRepository;

    [SetUp]
    public void SetUp() {
        _orderRepository = new InMemoryOrdersRepository();
        _productsRepository = Substitute.For<IProductsRepository>();
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _createOrderCommandHandler = new CreateOrderCommandHandler(_orderRepository, _productsRepository, _clock);
    }

    [Test]
    public async Task CreateANewOrderWithoutProducts() {
        var testOrder = OrdersMother.ACreatOrderDtoWithoutProducts();
        var createOrderCommand = new CreateOrderCommand(testOrder);

        await _createOrderCommandHandler.Handle(createOrderCommand, default);

        var expectedOrder = OrdersMother.ATestOrderWithoutProducts();
        var createdOrder = await _orderRepository.GetById(testOrder.Id);
        createdOrder.Should().BeEquivalentTo(expectedOrder);
    }

    [Test]
    public async Task CreateANewOrderWithProductList() {
        _productsRepository.GetById(ProductDefaultValues.ComputerMonitorId)
            .Returns(ProductDefaultValues.ComputerMonitor);
        var testOrder = OrdersMother.ACreateOrderDtoWithProducts();
        var createOrderCommand = new CreateOrderCommand(testOrder);

        await _createOrderCommandHandler.Handle(createOrderCommand, default);

        var expectedOrder = OrdersMother.ATestOrderWithAProduct();
        var createdOrder = await _orderRepository.GetById(testOrder.Id);
        createdOrder.Should().BeEquivalentTo(expectedOrder);
    }
}