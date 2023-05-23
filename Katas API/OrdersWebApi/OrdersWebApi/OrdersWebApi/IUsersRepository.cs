namespace OrdersWebApi.Tests;

public interface IUsersRepository { 
    User GetById(string userId);
    void Create(User user);
}