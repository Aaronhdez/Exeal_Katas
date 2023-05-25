namespace OrdersWebApi.Users;

public class User {
    public User(string id, string name, string address) {
        if (id == null) throw new ArgumentException();
        Id = id;
        Name = name;
        Address = address;
    }
    public string Name { get; }
    public string Address { get; }
    public string Id { get; }
}