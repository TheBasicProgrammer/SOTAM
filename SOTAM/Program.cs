using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SOTAM.Models;  

class Program
{
   // static void Main(string[] args)
   // {
        
      //  var configuration = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json")
        //    .Build();

        
     //   var serviceProvider = new ServiceCollection()
      //      .AddDbContext<SotamContext>(options =>
     //           options.UseSqlServer(configuration.GetConnectionString("SOTAM"))) 
      //      .BuildServiceProvider();

        
     //   var context = serviceProvider.GetRequiredService<SotamContext>();

        
      //  Console.WriteLine("Database connection is established!");

        
     //   var tables = context.Tables.ToList();  
     //   foreach (var table in tables)
     //   {
     //       Console.WriteLine($"Table {table.TableId} - {table.Status}");
    //    }
 //   }
}
