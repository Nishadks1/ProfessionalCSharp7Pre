using System;
using System.Threading.Tasks;

namespace DependencyInjectionWithContainer
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
