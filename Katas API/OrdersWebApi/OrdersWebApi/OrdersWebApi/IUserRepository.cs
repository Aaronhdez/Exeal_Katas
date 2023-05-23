namespace OrdersWebApi.Tests;

public interface IUserRepository {
    User GetById(string anId);
}