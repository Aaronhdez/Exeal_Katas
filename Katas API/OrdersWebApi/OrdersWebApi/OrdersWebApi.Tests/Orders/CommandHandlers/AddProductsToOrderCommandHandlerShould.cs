using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Commands;
using OrdersWebApi.Orders.Commands.Dto;

namespace OrdersWebApi.Tests.Orders.Commands;

public class AddProductsToOrderCommandHandlerShould
{
    private IOrderRepository _orderRepository;
    private Order _givenOrderModel;
    private AddProductsToOrderCommandHandler _addProductsCommandHandler;

    [SetUp]
    public void SetUp()
    {
        _orderRepository = Substitute.For<IOrderRepository>();
        _addProductsCommandHandler = new AddProductsToOrderCommandHandler(_orderRepository);
        _givenOrderModel = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new Products(new List<Product>()));
    }

    [Test]
    public async Task AddOneProductToAnEmptySpecifiedOrder()
    {
        _orderRepository.GetById("ORD123456").Returns(_givenOrderModel);
        var givenAddProductsDto = new AddProductsDto("ORD123456", new Product[]
        {
            new("Computer Monitor", 100)
        });
        var addProductsToOrderCommand = new AddProductsToOrderCommand(givenAddProductsDto);
        
        await _addProductsCommandHandler.Handle(addProductsToOrderCommand, default);

        var expectedOrderModel = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new Products(new List<Product>
            {
                new("Computer Monitor", 100)
            }));

        _orderRepository.Received().GetById("ORD123456");
        _orderRepository.Received().Update(expectedOrderModel);
    }

    [Test]
    public async Task AddTwoProductsToAnEmptySpecifiedOrder()
    {
        _orderRepository.GetById("ORD123456").Returns(_givenOrderModel);
        var givenAddProductsDto = new AddProductsDto("ORD123456", new Product[]
        {
            new("Computer Monitor", 100),
            new("Computer Monitor", 100)
        });
        var addProductsToOrderCommand = new AddProductsToOrderCommand(givenAddProductsDto);
        
        await _addProductsCommandHandler.Handle(addProductsToOrderCommand, default);

        var expectedOrderModel = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new Products(new List<Product>
            {
                new("Computer Monitor", 100),
                new("Computer Monitor", 100)
            }));

        _orderRepository.Received().GetById("ORD123456");
        _orderRepository.Received().Update(expectedOrderModel);
    }
}