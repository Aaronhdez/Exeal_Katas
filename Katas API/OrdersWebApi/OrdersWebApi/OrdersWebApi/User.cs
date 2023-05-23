﻿namespace OrdersWebApi;

public class User {
    public User(string id, string name, string address) {
        Id = id;
        Name = name;
        Address = address;
    }
    public string Name { get; }
    public string Address { get; }
    public string Id { get; }
}