namespace OrdersWebApi.Users;

public class Address {
    public Address(string value) {
        if (string.IsNullOrEmpty(value)) throw new ArgumentException();
        Value = value;
    }
    public string Value { get; }
}