using MediatR;

namespace OrdersWebApi.Orders.Commands.AddProductsToOrder;

#pragma warning disable CS8602

public class AddProductsToOrderCommand : IRequest {
    public AddProductsToOrderCommand(AddProductsDto addProductsDto) {
        Id = addProductsDto.Id;
        Products = addProductsDto.Products.ToList();
    }

    public string Id { get; }
    public List<Item> Products { get; }
}