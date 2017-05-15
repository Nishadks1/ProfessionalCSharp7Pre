using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionWithContainer
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
            services.AddSingleton<IBooksService, BooksService>();
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