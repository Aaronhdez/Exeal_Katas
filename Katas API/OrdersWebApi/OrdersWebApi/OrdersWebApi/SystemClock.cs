namespace OrdersWebApi;

public class SystemClock : IClock {
    public DateTime Timestamp() {
        return DateTime.Now;
    }
}