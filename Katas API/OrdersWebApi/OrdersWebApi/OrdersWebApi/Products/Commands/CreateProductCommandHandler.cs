﻿using MediatR;

namespace OrdersWebApi.Products.Commands;

public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand> {
    private readonly IProductsRepository _repository;

    public CreateProductCommandHandler(IProductsRepository repository) {
        _repository = repository;
    }

    public Task Handle(CreateProductCommand command, CancellationToken cancellationToken) {
        var item = new Product(
            command.ProductDto.Id,
            "A product Reference",
            command.ProductDto.Type,
            command.ProductDto.Name,
            command.ProductDto.Description,
            command.ProductDto.Manufacturer,
            command.ProductDto.ManufacturerReference,
            command.ProductDto.Value);
        _repository.Create(item);
        return Task.CompletedTask;
    }
}