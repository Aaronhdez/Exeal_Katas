using FluentAssertions;
using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Commands.AddProductsToOrder;
using OrdersWebApi.Orders.Repositories;
using OrdersWebApi.Products;
using OrdersWebApi.Tests.Products;

namespace OrdersWebApi.Tests.Orders.CommandHandlers;

public class AddProductsToOrderCommandHandlerShould {
    private AddProductsToOrderCommandHandler _addProductsCommandHandler;
    private Order _givenOrderModel;
    private IOrderRepository _orderRepository;
    private IProductsRepository _productsRepository;

    [SetUp]
    public void SetUp() {
        _orderRepository = new InMemoryOrdersRepository();
        _productsRepository = Substitute.For<IProductsRepository>();
        _productsRepository.GetById(ProductDefaultValues.ComputerMonitorId)
            .Returns(ProductDefaultValues.ComputerMonitor);
        _addProductsCommandHandler = new AddProductsToOrderCommandHandler(_orderRepository, _productsRepository);
        _givenOrderModel = OrdersMother.ATestOrderWithoutProducts();
    }

    [Test]
    public async Task AddOneProductToAnEmptySpecifiedOrder() {
        await _orderRepository.Create(_givenOrderModel);
        var givenAddProductsDto = ProductsMother.AddAProductDto();
        var addProductsToOrderCommand = new AddProductsToOrderCommand(givenAddProductsDto);

        await _addProductsCommandHandler.Handle(addProductsToOrderCommand, default);

        var expectedOrderModel = OrdersMother.ATestOrderWithAProduct();
        var updatedOrder = await _orderRepository.GetById(OrderDefaultValues.OrderId);
        updatedOrder.Should().BeEquivalentTo(expectedOrderModel);
    }

    [Test]
    public async Task AddTwoProductsToAnEmptySpecifiedOrder() {
        await _orderRepository.Create(_givenOrderModel);
        var givenAddProductsDto = ProductsMother.AddTwoProductsDto();
        var addProductsToOrderCommand = new AddProductsToOrderCommand(givenAddProductsDto);

        await _addProductsCommandHandler.Handle(addProductsToOrderCommand, default);

        var expectedOrderModel = OrdersMother.AnUpdatedTestOrderWithTwoProducts();
        var updatedOrder = await _orderRepository.GetById(OrderDefaultValues.OrderId);
        updatedOrder.Should().BeEquivalentTo(expectedOrderModel);
    }
}