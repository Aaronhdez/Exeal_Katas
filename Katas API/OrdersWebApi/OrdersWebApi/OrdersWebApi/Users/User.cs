using System.Security;

namespace OrdersWebApi.Users;

public class UserData {
    public UserData(string name) {
        Name = name;
    }
    public string Name { get; private set; }
}

public class User {
    public User(string id, UserData userData, string address) {
        ValidateData(id, userData.Name, address);
        Id = id;
        Name = userData.Name;
        Address = address;
    }

    private static void ValidateData(string id, string name, string address) {
        if (string.IsNullOrEmpty(id)) throw new ArgumentException();
        if (string.IsNullOrEmpty(name)) throw new ArgumentException();
        if (string.IsNullOrEmpty(address)) throw new ArgumentException();
    }

    public string Name { get; }
    public string Address { get; }
    public string Id { get; }
}