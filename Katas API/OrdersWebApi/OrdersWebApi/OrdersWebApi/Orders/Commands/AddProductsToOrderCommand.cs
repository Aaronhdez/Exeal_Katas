using MediatR;
using OrdersWebApi.Orders.Commands.Dto;

namespace OrdersWebApi.Orders.Commands;

#pragma warning disable CS8602

public class AddProductsToOrderCommand : IRequest
{
    public AddProductsToOrderCommand(AddProductsDto addProductsDto)
    {
        Id = addProductsDto.Id;
        Products = addProductsDto.Products.ToList();
    }

    public string Id { get; }
    public List<Product> Products { get; }
}