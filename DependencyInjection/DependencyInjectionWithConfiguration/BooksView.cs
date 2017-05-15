using System;
using System.Threading.Tasks;

namespace DependencyInjectionWithConfiguration
{
    public class BooksView
    {
        private readonly IBooksService _booksService;
        public BooksView(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task ShowAllBooksAsync()
        {
            foreach (var book in await _booksService.GetBooksAsync())
            {
                Console.WriteLine(book);
            }
        }
    }
}
