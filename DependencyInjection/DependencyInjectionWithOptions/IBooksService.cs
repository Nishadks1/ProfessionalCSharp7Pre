using System.Collections.Generic;
using System.Threading.Tasks;

namespace DependencyInjectionWithOptions
{
    public interface IBooksService
    {
        ValueTask<IEnumerable<Book>> GetBooksAsync();
    }
}