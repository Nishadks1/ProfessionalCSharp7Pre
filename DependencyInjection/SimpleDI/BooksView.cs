using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDI
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
