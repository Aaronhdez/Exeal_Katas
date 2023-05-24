using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Commands.AddProductsToOrder;
using OrdersWebApi.Orders.Repositories;
using OrdersWebApi.Products;
using OrdersWebApi.Tests.Products;
using OrdersWebApi.TestUtils.Products;

namespace OrdersWebApi.Tests.Orders.CommandHandlers;

public class AddProductsToOrderCommandHandlerShould {
    private AddProductsToOrderCommandHandler _addProductsCommandHandler;
    private Order _givenOrderModel;
    private IOrderRepository _orderRepository;
    private IProductsRepository _productsRepository;

    [SetUp]
    public async Task SetUp() {
        _orderRepository = new InMemoryOrdersRepository();
        _productsRepository = Substitute.For<IProductsRepository>();
        _productsRepository.GetById(ProductDefaultValues.ComputerMonitorId).Returns(ProductsMother.ComputerMonitor());
        _addProductsCommandHandler = new AddProductsToOrderCommandHandler(_orderRepository, _productsRepository);
        _givenOrderModel = OrdersMother.ATestOrderWithoutProducts();
        await _orderRepository.Create(_givenOrderModel);
    }

    [Test]
    public async Task AddOneProductToAnEmptySpecifiedOrder() {
        var givenAddProductsDto = ProductsMother.AddAProductDto();
        var addProductsToOrderCommand = new AddProductsToOrderCommand(givenAddProductsDto);

        await _addProductsCommandHandler.Handle(addProductsToOrderCommand, default);
        
        await Verify(await _orderRepository.GetById(_givenOrderModel.Id));
    }

    [Test]
    public async Task AddTwoProductsToAnEmptySpecifiedOrder() {
        var givenAddProductsDto = ProductsMother.AddTwoProductsDto();
        var addProductsToOrderCommand = new AddProductsToOrderCommand(givenAddProductsDto);

        await _addProductsCommandHandler.Handle(addProductsToOrderCommand, default);
        
        await Verify(await _orderRepository.GetById(_givenOrderModel.Id));
    }
}