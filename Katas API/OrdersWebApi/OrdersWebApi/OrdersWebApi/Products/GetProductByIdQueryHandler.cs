﻿using MediatR;
using OrdersWebApi.Orders;

namespace OrdersWebApi.Tests.Products;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductReadDto> {
    private readonly IProductsRepository _repository;

    public GetProductByIdQueryHandler(IProductsRepository repository) {
        _repository = repository;
    }

    public async Task<ProductReadDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) {
        return await _repository.GetReadDtoById(request.Id);
    }
}