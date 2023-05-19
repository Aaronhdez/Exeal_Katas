using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersWebApi.Bills.Queries;

namespace OrdersWebApi.Bills;

[ApiController]
[Route("[controller]")]
public class BillsController {
    private readonly ISender _sender;

    public BillsController(ISender sender) {
        _sender = sender;
    }

    [HttpGet("{orderId}")]
    public Task<ReadBillDto> Get(string orderId) {
        return _sender.Send(new GetBillByOrderIdQuery(orderId));
    }
}