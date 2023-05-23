namespace OrdersWebApi.Tests;

public interface IUserRepository { 
    User GetById(string userId);
    void Create(User user);
}