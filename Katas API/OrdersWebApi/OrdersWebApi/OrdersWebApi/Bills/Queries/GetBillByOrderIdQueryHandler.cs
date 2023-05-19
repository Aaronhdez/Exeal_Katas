using MediatR;
using OrdersWebApi.Orders;

namespace OrdersWebApi.Bills.Queries; 

public class GetBillByOrderIdQueryHandler : IRequestHandler<GetBillByOrderIdQuery, ReadBillDto> {
    
    private readonly IOrderRepository _ordersRepository;

    public GetBillByOrderIdQueryHandler(IOrderRepository ordersRepository) {
        _ordersRepository = ordersRepository;
    }
    
    public Task<ReadBillDto> Handle(GetBillByOrderIdQuery request, CancellationToken cancellationToken) {
        var order = _ordersRepository.GetById(request.Id).Result;
        return Task.FromResult(new Bill(order).ToReadDto());
    }
}