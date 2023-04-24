using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace OrdersWebApi.Tests;

public class OrdersApi : WebApplicationFactory<Api>
{
    //private readonly IClock _clock;
    //private SQLiteConnection _sqLiteConnection;
    
    public OrdersApi()
    {
        //_clock = clock;
        //_sqLiteConnection = new SQLiteConnection("Data Source=:memory:");
        //_sqLiteConnection.Open();
        //_sqLiteConnection.Execute(@"Create Table if not exists Messages(
        //        Author VARCHAR(100) NOT NULL,
        //        Content VARCHAR(144) NOT NULL,
        //        Timestamp DATETIME NOT NULL)");
        //_sqLiteConnection.Execute(@"Create Table if not exists Subscriptions(
        //        User VARCHAR(100) NOT NULL,
        //        Subscriber VARCHAR(100) NOT NULL)");
    }
    
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            //services.AddSingleton(_clock);
            //services.AddSingleton(_sqLiteConnection);
            //services.AddSingleton<IMessagesRepository, InMemoryMessagesRepository>();
            //services.AddSingleton<ISubscriptionRepository, InMemorySubscriptionRepository>();
        });
    
        return base.CreateHost(builder);
    }
}