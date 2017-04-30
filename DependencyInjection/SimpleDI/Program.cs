using System;

namespace SimpleDI
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        private static async System.Threading.Tasks.Task RunAsync()
        {
            var view = new BooksView(new BooksService());
            await view.ShowAllBooksAsync();
        }
    }
}
