using FluentAssertions;
using NSubstitute;
using OrdersWebApi.Commands.Orders;
using OrdersWebApi.Controllers.Orders.Dto;
using OrdersWebApi.Models.Orders;

namespace OrdersWebApi.Tests.Commands;

public class AddProductsToOrderCommandShould
{
    private AddProductsToOrderCommand? _addProductsToOrderCommand;
    private IOrderRepository _orderRepository;
    private Order _givenOrderModel;

    [SetUp]
    public void SetUp()
    {
        _orderRepository = Substitute.For<IOrderRepository>();
        _addProductsToOrderCommand = new AddProductsToOrderCommand(_orderRepository);
        _givenOrderModel = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new Products(new ()));
    }

    [Test]
    public void AddOneProductToAnEmptySpecifiedOrder()
    {
        _orderRepository.GetById("ORD123456").Returns(_givenOrderModel);
        var givenAddProductsDto = new AddProductsDto("ORD123456", new Product[]
        {
            new("Computer Monitor", 100)
        });
        
        _addProductsToOrderCommand.Execute(givenAddProductsDto);

        var expectedOrderModel = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new Products(new List<Product>
            {
                new("Computer Monitor", 100)
            }));

        _orderRepository.Received().GetById("ORD123456");
        _orderRepository.Received().Update(expectedOrderModel);
    }
}