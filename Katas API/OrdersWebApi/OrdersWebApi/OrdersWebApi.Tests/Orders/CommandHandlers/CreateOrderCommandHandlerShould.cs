using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Commands.CreateOrder;
using OrdersWebApi.Orders.Repositories;
using OrdersWebApi.Products;
using OrdersWebApi.Tests.Products;
using OrdersWebApi.Tests.Users;
using OrdersWebApi.TestUtils;
using OrdersWebApi.TestUtils.Users;
using OrdersWebApi.Users;

namespace OrdersWebApi.Tests.Orders.CommandHandlers;

public class CreateOrderCommandHandlerShould {
    private IClock _clock;
    private CreateOrderCommand _createOrderCommand;
    private CreateOrderCommandHandler _createOrderCommandHandler;
    private IOrderRepository _orderRepository;
    private IProductsRepository _productsRepository;
    private IUsersRepository _usersRepository;

    [SetUp]
    public void SetUp() {
        _orderRepository = new InMemoryOrdersRepository();
        _usersRepository = Substitute.For<IUsersRepository>();
        _usersRepository.GetById(UserDefaultValues.CustomerId).Returns(UsersMother.TestUser());
        _usersRepository.GetById(UserDefaultValues.VendorId).Returns(UsersMother.TestVendor());
        _productsRepository = Substitute.For<IProductsRepository>();
        _clock = Substitute.For<IClock>();
        _clock.Timestamp().Returns(TestDefaultValues.CreationDateTime);
        _createOrderCommandHandler = new CreateOrderCommandHandler(_orderRepository, _productsRepository, _usersRepository, _clock);
    }

    [Test]
    public async Task CreateANewOrderWithoutProducts() {
        var testOrder = OrdersMother.ACreatOrderDtoWithoutProducts();
        var createOrderCommand = new CreateOrderCommand(testOrder);

        await _createOrderCommandHandler.Handle(createOrderCommand, default);
        
        await Verify(await _orderRepository.GetById(testOrder.Id));
    }

    [Test]
    public async Task CreateANewOrderWithProductList() {
        _productsRepository.GetById(ProductDefaultValues.ComputerMonitorId)
            .Returns(ProductDefaultValues.ComputerMonitor);
        var testOrder = OrdersMother.ACreateOrderDtoWithProducts();
        var createOrderCommand = new CreateOrderCommand(testOrder);

        await _createOrderCommandHandler.Handle(createOrderCommand, default);

        await Verify(await _orderRepository.GetById(testOrder.Id));
    }
}