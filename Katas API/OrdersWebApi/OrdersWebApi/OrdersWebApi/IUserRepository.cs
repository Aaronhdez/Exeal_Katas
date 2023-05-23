namespace OrdersWebApi.Tests;

public interface IUserRepository { 
    User GetById(string userId);
    string Create(User user);
}