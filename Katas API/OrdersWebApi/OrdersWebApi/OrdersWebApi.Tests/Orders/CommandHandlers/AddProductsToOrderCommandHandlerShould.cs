using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Commands.AddProductsToOrder;
using OrdersWebApi.Tests.Acceptance;

namespace OrdersWebApi.Tests.Orders.CommandHandlers;

public class AddProductsToOrderCommandHandlerShould {
    private AddProductsToOrderCommandHandler _addProductsCommandHandler;
    private Order _givenOrderModel;
    private IOrderRepository _orderRepository;

    [SetUp]
    public void SetUp() {
        _orderRepository = Substitute.For<IOrderRepository>();
        _addProductsCommandHandler = new AddProductsToOrderCommandHandler(_orderRepository);
        _givenOrderModel = new Order(
            TestDefaultValues.OrderId,
            TestDefaultValues.CreationDate,
            TestDefaultValues.CustomerName,
            TestDefaultValues.CustomerAddress,
            new List<Item>());
    }

    [Test]
    public async Task AddOneProductToAnEmptySpecifiedOrder() {
        _orderRepository.GetById(TestDefaultValues.OrderId).Returns(_givenOrderModel);
        var givenAddProductsDto = new AddProductsDto(TestDefaultValues.OrderId, new Item[] {
            TestDefaultValues.ComputerMonitor
        });
        var addProductsToOrderCommand = new AddProductsToOrderCommand(givenAddProductsDto);

        await _addProductsCommandHandler.Handle(addProductsToOrderCommand, default);

        var expectedOrderModel = new Order(TestDefaultValues.OrderId, TestDefaultValues.CreationDate,
            TestDefaultValues.CustomerName, TestDefaultValues.CustomerAddress,
            new List<Item> {
                TestDefaultValues.ComputerMonitor
            });

        await _orderRepository.Received().GetById(TestDefaultValues.OrderId);
        await _orderRepository.Received().Update(expectedOrderModel);
    }

    [Test]
    public async Task AddTwoProductsToAnEmptySpecifiedOrder() {
        _orderRepository.GetById(TestDefaultValues.OrderId).Returns(_givenOrderModel);
        var givenAddProductsDto = new AddProductsDto(TestDefaultValues.OrderId, new Item[] {
            TestDefaultValues.ComputerMonitor,
            TestDefaultValues.ComputerMonitor
        });
        var addProductsToOrderCommand = new AddProductsToOrderCommand(givenAddProductsDto);

        await _addProductsCommandHandler.Handle(addProductsToOrderCommand, default);

        var expectedOrderModel = new Order(TestDefaultValues.OrderId, TestDefaultValues.CreationDate,
            TestDefaultValues.CustomerName, TestDefaultValues.CustomerAddress,
            new List<Item> {
                TestDefaultValues.ComputerMonitor,
                TestDefaultValues.ComputerMonitor
            });

        await _orderRepository.Received().GetById(TestDefaultValues.OrderId);
        await _orderRepository.Received().Update(expectedOrderModel);
    }
}