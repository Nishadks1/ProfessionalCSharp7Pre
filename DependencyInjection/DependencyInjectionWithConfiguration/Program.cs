using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DependencyInjectionWithConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterServices();
            RunAsync().Wait();
        }

        private static void RegisterServices()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();      

            var services = new ServiceCollection();
            services.AddOptions();
           
            services.AddBooksService(configuration.GetSection("BooksFileService"));
            
            services.AddTransient<BooksView>();
            Container = services.BuildServiceProvider();
        }

        public static IServiceProvider Container { get; private set; }

        private static async Task RunAsync()
        {
            var view = Container.GetService<BooksView>();
            await view.ShowAllBooksAsync();
        }
    }
}