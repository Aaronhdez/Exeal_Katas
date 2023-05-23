namespace OrdersWebApi;

public class User {
    public User(string name, string address) {
        Name = name;
        Address = address;
    }
    public string Name { get; }
    public string Address { get; }
}