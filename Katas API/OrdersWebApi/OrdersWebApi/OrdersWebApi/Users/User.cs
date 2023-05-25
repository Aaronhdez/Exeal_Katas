using System.Security;

namespace OrdersWebApi.Users;

public class User {
    public User(string id, UserData userData, Address address) {
        if (string.IsNullOrEmpty(id)) throw new ArgumentException();
        Id = id;
        Name = userData.Name;
        Address = address.Value;
    }

    public string Name { get; }
    public string Address { get; }
    public string Id { get; }
}