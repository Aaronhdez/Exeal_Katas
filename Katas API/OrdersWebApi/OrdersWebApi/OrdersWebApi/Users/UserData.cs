namespace OrdersWebApi.Users;

public class UserData {
    public UserData(string name) {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException();
        Name = name;
    }
    public string Name { get; }
}