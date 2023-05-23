namespace OrdersWebApi.Users;

public interface IUsersRepository { 
    User GetById(string userId);
    void Create(User user);
}