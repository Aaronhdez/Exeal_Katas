﻿using System.Runtime.InteropServices.JavaScript;
using FluentAssertions;
using NSubstitute;
using OrdersWebApi.Commands.Orders;
using OrdersWebApi.Controllers.Orders;
using OrdersWebApi.Controllers.Orders.Dto;
using OrdersWebApi.Controllers.Orders.Requests;
using OrdersWebApi.Models.Orders;
using OrdersWebApi.Queries;

#pragma warning disable CS8602

namespace OrdersWebApi.Tests.Controllers;

public class OrdersControllerShould
{
    private OrdersController? _ordersController;
    private IClock? _clock;
    private CreateOrderCommand? _createOrderCommand;
    private GetOrderByIdQuery? _getOrderByIdQuery;
    private AddProductsToOrderCommand? _addProductsToOrderCommand;
    private IOrderRepository _ordersRepository;
    private string _defaultOrderId = "ORD123456";

    [SetUp]
    public void SetUp()
    {
        _clock = Substitute.For<IClock>();
        _ordersRepository = Substitute.For<IOrderRepository>();
        _createOrderCommand = Substitute.For<CreateOrderCommand>(_ordersRepository);
        _addProductsToOrderCommand = Substitute.For<AddProductsToOrderCommand>(_ordersRepository);
        _getOrderByIdQuery = Substitute.For<GetOrderByIdQuery>(new object[] { null });
        _ordersController =
            new OrdersController(_clock, _createOrderCommand, _addProductsToOrderCommand, _getOrderByIdQuery);
    }

    [Test]
    public async Task PostAnOrderWithoutProductsSuccess()
    {
        _clock.Timestamp().Returns(new DateTime(2023, 04, 24));

        var createOrderRequest =
            new CreateOrderRequest(_defaultOrderId, "John Doe", "A Simple Street, 123", new Product[] { });
        await _ordersController.Post(createOrderRequest);

        var expectedCreateOrderDto = new CreateOrderDto(_defaultOrderId, new DateTime(2023, 04, 24), "John Doe",
            "A Simple Street, 123", new Product[] { });
        _createOrderCommand.Received().Execute(expectedCreateOrderDto);
    }

    [Test]
    public async Task PostAnOrderWithProductsSuccess()
    {
        _clock.Timestamp().Returns(new DateTime(2023, 04, 24));

        var createOrderRequest = new CreateOrderRequest(_defaultOrderId, "John Doe", "A Simple Street, 123",
            new Product[]
            {
                new("Computer Monitor", 100)
            });
        await _ordersController.Post(createOrderRequest);

        var expectedCreateOrderDto = new CreateOrderDto(_defaultOrderId, new DateTime(2023, 04, 24), "John Doe",
            "A Simple Street, 123", new Product[] { new("Computer Monitor", 100) });
        _createOrderCommand.Received().Execute(expectedCreateOrderDto);
    }

    [Test]
    public async Task PutAnOrderWithANewProduct()
    {
        _clock.Timestamp().Returns(new DateTime(2023, 04, 24));
        var addProductsRequest = new AddProductsRequest(new Product[]
        {
            new("Computer Monitor", 100)
        });

        await _ordersController.Put(_defaultOrderId, addProductsRequest);

        var expectedAddProductsDto = new AddProductsDto(_defaultOrderId, addProductsRequest.Products);
        _addProductsToOrderCommand.Received().Execute(expectedAddProductsDto);
    }
}