namespace OrdersWebApi;

#pragma warning disable CS8602
public class CreateOrderCommand
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommand(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void Execute(CreateOrderDto createOrderDto)
    {
        var orderModel = new Order(
            createOrderDto.Id,
            createOrderDto.Timestamp.ToString("dd/MM/yyyy"),
            createOrderDto.Customer, 
            createOrderDto.Address, 
            new Products(createOrderDto.Products));
        _orderRepository.Create(orderModel);
    }
}