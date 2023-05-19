using MediatR;

namespace OrdersWebApi.Bills.Queries;

public class GetBillByOrderIdQuery : IRequest<ReadBillDto> {
    public GetBillByOrderIdQuery(string id) {
        Id = id;
    }

    public string Id { get; }
}