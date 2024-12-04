using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SOTAM;  // Ensure this matches your project's namespace

class Program
{
    static void Main(string[] args)
    {
        // Build a configuration object to load the appsettings.json file
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // Set up Dependency Injection (DI) for services
        var serviceProvider = new ServiceCollection()
            .AddDbContext<SOTAMContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SOTAM"))) // Get connection string from appsettings
            .BuildServiceProvider();

        // Get the DbContext instance from DI container
        var context = serviceProvider.GetRequiredService<SOTAMContext>();

        // Now you can use the context to interact with the database
        Console.WriteLine("Database connection is established!");

        // Example of interacting with the database
        var tables = context.Tables.ToList();  // Fetching tables from the database
        foreach (var table in tables)
        {
            Console.WriteLine($"Table {table.TableID} - {table.Status}");
        }
    }
}
