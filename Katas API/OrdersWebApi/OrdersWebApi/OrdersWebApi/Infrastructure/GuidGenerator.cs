namespace OrdersWebApi;

class GuidGenerator : IGuidGenerator {
    public Guid NewId() {
        return Guid.NewGuid();
    }
}