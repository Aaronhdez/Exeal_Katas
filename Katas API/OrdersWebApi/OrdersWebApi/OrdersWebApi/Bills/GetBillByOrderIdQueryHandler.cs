using MediatR;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Queries;

namespace OrdersWebApi.Bills; 

public class GetBillByOrderIdQueryHandler : IRequestHandler<GetBillByOrderIdQuery, ReadBillDto> {
    
    private readonly IOrderRepository _ordersRepository;

    public GetBillByOrderIdQueryHandler(IOrderRepository ordersRepository) {
        _ordersRepository = ordersRepository;
    }
    
    public Task<ReadBillDto> Handle(GetBillByOrderIdQuery request, CancellationToken cancellationToken) {
        var id = request.Id;
        return null;
    }
}