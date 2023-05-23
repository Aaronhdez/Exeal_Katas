namespace OrdersWebApi.Tests;

public class InMemoryUsersRepository : IUserRepository {
    private Dictionary<string, User> _dictionary;

    public InMemoryUsersRepository() {
        _dictionary = new Dictionary<string, User>();
    }

    public User GetById(string userId) {
        return null;
        return _dictionary[userId];
    }

    public string Create(User user) {
        return string.Empty;
    }
}