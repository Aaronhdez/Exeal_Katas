using OrdersWebApi.Users;
using OrdersWebApi.Users.Commands;
using OrdersWebApi.Users.Controllers;
using OrdersWebApi.Users.Queries;

namespace OrdersWebApi.Tests.Users;

public class UsersMother {
    
    //REQUESTS & RESPONSES
    public static CreateUserRequest TestCreateCustomerRequest() {
        return new CreateUserRequest(UserDefaultValues.CustomerName, UserDefaultValues.CustomerAddress);
    }    
    public static CreateUserRequest TestCreateVendorRequest() {
        return new CreateUserRequest(UserDefaultValues.VendorName, UserDefaultValues.VendorAddress);
    }
    
    //DTOS
    public static CreateUserDto TestUserCreateDto() {
        return new CreateUserDto(UserDefaultValues.CustomerId, UserDefaultValues.CustomerName, UserDefaultValues.CustomerAddress);
    }

    public static ReadUserDto TestReadCustomerDto() {
        return new ReadUserDto(UserDefaultValues.CustomerId, UserDefaultValues.CustomerName, UserDefaultValues.CustomerAddress);
    }

    public static ReadUserDto TestReadVendorDto() {
        return new ReadUserDto(UserDefaultValues.VendorId, UserDefaultValues.VendorName, UserDefaultValues.VendorAddress);
    }

    //MODELS
    public static User TestUser() {
        return new User(UserDefaultValues.CustomerId, UserDefaultValues.CustomerName, UserDefaultValues.CustomerAddress);
    }

    public static User TestVendor() {
        return new User(UserDefaultValues.VendorId, UserDefaultValues.VendorName, UserDefaultValues.VendorAddress);
    }
}