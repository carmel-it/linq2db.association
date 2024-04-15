using Linq2db.AssociationIssue.Data;
using Linq2db.AssociationIssue.MemberAggregate;
using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration((_, config) =>
    {
        config.SetBasePath(Directory.GetCurrentDirectory());
        config.AddJsonFile("appsettings.json", false, true);
        config.AddJsonFile("appsettings.Development.json", true,
            true);
    })
    .ConfigureServices((context, services) =>
    {
        var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

        if (connectionString is null) throw new NullReferenceException("Connection string is missing");

        services.AddLinqToDBContext<CarmelContext>((provider, options) => options
            // .UseSqlServer(connectionString)
            .UseSQLite(connectionString)
            .UseDefaultLogging(provider));

        services.AddHostedService<DataLoaderService>();
    });

var app = builder.Build();
app.Run();


public class DataLoaderService(CarmelContext dataContext) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Fetching data");

        var member = dataContext
            .GetTable<Member>()
            .LoadWith(m => m.ThemeSettings)
            .FirstOrDefault();

        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(member));
        Console.WriteLine(member is null ? "BAD! Member is null!" : "GOOD: Member found!");

        var settings = member?.ThemeSettings;
        Console.WriteLine(settings is null ? "BAD! ThemeSettings is null!" : "GOOD: ThemeSettings loaded!");

        if (member is not null)
        {
            var themeSettings = dataContext.GetTable<ThemeSettings>().FirstOrDefault(ts => ts.MemberId == member.Id);
            Console.WriteLine(themeSettings is null ? "BAD! ThemeSettings is null!" : "GOOD: ThemeSettings loaded!");
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(themeSettings));
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}