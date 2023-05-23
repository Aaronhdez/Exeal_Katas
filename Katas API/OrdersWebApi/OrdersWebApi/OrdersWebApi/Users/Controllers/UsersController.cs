using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Users.Commands;
using OrdersWebApi.Users.Queries;

namespace OrdersWebApi.Users.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController {
    private IGuidGenerator _guidGenerator;
    private ISender _sender;

    public UsersController(IGuidGenerator guidGenerator, ISender sender) {
        _guidGenerator = guidGenerator;
        _sender = sender;
    }

    [HttpPost]
    public async Task<string> Post(CreateUserRequest request) {
        var id = _guidGenerator.NewId().ToString();
        await _sender.Send(new CreateUserCommand(new CreateUserDto(id, request.Name, request.Address)));
        return await Task.FromResult(id);
    }

    [HttpGet("{id}")]
    public Task<ReadUserDto> Get(string id) {
        return _sender.Send(new GetUserByIdQuery(id));
    }
}