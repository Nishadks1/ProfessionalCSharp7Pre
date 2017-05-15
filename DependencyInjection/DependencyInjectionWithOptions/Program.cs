using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DependencyInjectionWithOptions
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
            var services = new ServiceCollection();
            services.AddOptions();
            services.AddBooksService(options => options.FileName = "books.json");
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