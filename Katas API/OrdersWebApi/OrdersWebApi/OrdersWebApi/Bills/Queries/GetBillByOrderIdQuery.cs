using MediatR;

namespace OrdersWebApi.Bills.Queries;

public class GetBillByOrderIdQuery : IRequest<ReadBillDto> {
    public string Id { get; }

    public GetBillByOrderIdQuery(string id) {
        Id = id;
    }
}