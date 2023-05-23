namespace OrdersWebApi.Tests;

public class InMemoryUsersRepository : IUserRepository {
    private Dictionary<string, User> _dictionary;

    public InMemoryUsersRepository() {
        _dictionary = new Dictionary<string, User>();
    }

    public User GetById(string userId) {
        if (_dictionary.ContainsKey(userId)) return _dictionary[userId];
        return null;
    }

    public void Create(User user) {
        _dictionary.Add(user.Id, user);
    }
}