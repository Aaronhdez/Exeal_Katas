using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Commands.AddProductsToOrder;
using OrdersWebApi.Products;

namespace OrdersWebApi.Tests.Orders.CommandHandlers;

public class AddProductsToOrderCommandHandlerShould {
    private AddProductsToOrderCommandHandler _addProductsCommandHandler;
    private Order _givenOrderModel;
    private IOrderRepository _orderRepository;
    private IProductsRepository _productsRepository;

    [SetUp]
    public void SetUp() {
        _orderRepository = Substitute.For<IOrderRepository>();
        _productsRepository = Substitute.For<IProductsRepository>();
        _addProductsCommandHandler = new AddProductsToOrderCommandHandler(_orderRepository, _productsRepository);
        _givenOrderModel = new Order(
            TestDefaultValues.OrderId,
            TestDefaultValues.CreationDate,
            TestDefaultValues.CustomerName,
            TestDefaultValues.CustomerAddress,
            new List<Product>());
    }

    [Test]
    public async Task AddOneProductToAnEmptySpecifiedOrder() {
        _productsRepository.GetById(TestDefaultValues.ComputerMonitorId).Returns(TestDefaultValues.ComputerMonitor);
        _orderRepository.GetById(TestDefaultValues.OrderId).Returns(_givenOrderModel);
        var givenAddProductsDto = new AddProductsDto(TestDefaultValues.OrderId, new [] {
            TestDefaultValues.ComputerMonitorId
        });
        var addProductsToOrderCommand = new AddProductsToOrderCommand(givenAddProductsDto);

        await _addProductsCommandHandler.Handle(addProductsToOrderCommand, default);

        var expectedOrderModel = new Order(TestDefaultValues.OrderId, TestDefaultValues.CreationDate,
            TestDefaultValues.CustomerName, TestDefaultValues.CustomerAddress,
            new List<Product> {
                TestDefaultValues.ComputerMonitor
            });

        await _orderRepository.Received().GetById(TestDefaultValues.OrderId);
        await _orderRepository.Received().Update(expectedOrderModel);
    }

    [Test]
    public async Task AddTwoProductsToAnEmptySpecifiedOrder() {
        _productsRepository.GetById(TestDefaultValues.ComputerMonitorId).Returns(TestDefaultValues.ComputerMonitor);
        _orderRepository.GetById(TestDefaultValues.OrderId).Returns(_givenOrderModel);
        var givenAddProductsDto = new AddProductsDto(TestDefaultValues.OrderId, new [] {
            TestDefaultValues.ComputerMonitorId,
            TestDefaultValues.ComputerMonitorId
        });
        var addProductsToOrderCommand = new AddProductsToOrderCommand(givenAddProductsDto);

        await _addProductsCommandHandler.Handle(addProductsToOrderCommand, default);

        var expectedOrderModel = new Order(TestDefaultValues.OrderId, TestDefaultValues.CreationDate,
            TestDefaultValues.CustomerName, TestDefaultValues.CustomerAddress,
            new List<Product> {
                TestDefaultValues.ComputerMonitor,
                TestDefaultValues.ComputerMonitor
            });

        await _orderRepository.Received().GetById(TestDefaultValues.OrderId);
        await _orderRepository.Received().Update(expectedOrderModel);
    }
}