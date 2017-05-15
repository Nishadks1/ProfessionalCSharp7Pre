using System.Collections.Generic;
using System.Threading.Tasks;

namespace DependencyInjectionWithConfiguration
{
    public class BooksService : IBooksService
    {
        public ValueTask<IEnumerable<Book>> GetBooksAsync() =>
            new ValueTask<IEnumerable<Book>>(
                new List<Book>()
                {
                    new Book("Professional C# 7", "Wrox Press"),
                    new Book("Professional C# 6", "Wrox Press")
                });
    }
}
