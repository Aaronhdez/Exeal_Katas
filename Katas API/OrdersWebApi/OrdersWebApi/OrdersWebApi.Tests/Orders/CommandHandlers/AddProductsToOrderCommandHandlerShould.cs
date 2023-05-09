using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Commands.AddProductsToOrder;

namespace OrdersWebApi.Tests.Orders.CommandHandlers;

public class AddProductsToOrderCommandHandlerShould {
    private AddProductsToOrderCommandHandler _addProductsCommandHandler;
    private Order _givenOrderModel;
    private IOrderRepository _orderRepository;

    [SetUp]
    public void SetUp() {
        _orderRepository = Substitute.For<IOrderRepository>();
        _addProductsCommandHandler = new AddProductsToOrderCommandHandler(_orderRepository);
        _givenOrderModel = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",new List<Item>());
    }

    [Test]
    public async Task AddOneProductToAnEmptySpecifiedOrder() {
        _orderRepository.GetById("ORD123456").Returns(_givenOrderModel);
        var givenAddProductsDto = new AddProductsDto("ORD123456", new Item[] {
            new("PROD000001", "Computer Monitor", 100)
        });
        var addProductsToOrderCommand = new AddProductsToOrderCommand(givenAddProductsDto);

        await _addProductsCommandHandler.Handle(addProductsToOrderCommand, default);

        var expectedOrderModel = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new List<Item> {
                new("PROD000001", "Computer Monitor", 100)
            });

        _orderRepository.Received().GetById("ORD123456");
        _orderRepository.Received().Update(expectedOrderModel);
    }

    [Test]
    public async Task AddTwoProductsToAnEmptySpecifiedOrder() {
        _orderRepository.GetById("ORD123456").Returns(_givenOrderModel);
        var givenAddProductsDto = new AddProductsDto("ORD123456", new Item[] {
            new("PROD000001", "Computer Monitor", 100),
            new("PROD000001", "Computer Monitor", 100)
        });
        var addProductsToOrderCommand = new AddProductsToOrderCommand(givenAddProductsDto);

        await _addProductsCommandHandler.Handle(addProductsToOrderCommand, default);

        var expectedOrderModel = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new List<Item> {
                new("PROD000001", "Computer Monitor", 100),
                new("PROD000001", "Computer Monitor", 100)
            });

        _orderRepository.Received().GetById("ORD123456");
        _orderRepository.Received().Update(expectedOrderModel);
    }
}