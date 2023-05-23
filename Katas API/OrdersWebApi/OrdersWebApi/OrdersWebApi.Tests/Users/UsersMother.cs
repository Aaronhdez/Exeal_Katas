using OrdersWebApi.Users;
using OrdersWebApi.Users.Commands;
using OrdersWebApi.Users.Controllers;
using OrdersWebApi.Users.Queries;

namespace OrdersWebApi.Tests.Users;

public class UsersMother {
    
    //REQUESTS & RESPONSES
    public static CreateUserRequest TestCreateUserRequest() {
        return new CreateUserRequest(UserDefaultValues.CustomerName, UserDefaultValues.CustomerAddress);
    }
    
    //DTOS
    public static CreateUserDto TestUserCreateDto() {
        return new CreateUserDto(UserDefaultValues.UserId, UserDefaultValues.CustomerName, UserDefaultValues.CustomerAddress);
    }

    public static ReadUserDto TestReadUserDto() {
        return new ReadUserDto(UserDefaultValues.UserId, UserDefaultValues.CustomerName, UserDefaultValues.CustomerAddress);
    }

    //MODELS
    public static User TestUser() {
        return new User(UserDefaultValues.UserId, UserDefaultValues.CustomerName, UserDefaultValues.CustomerAddress);
    }
}