using System.Collections.Generic;
using System.Threading.Tasks;

namespace DependencyInjectionWithConfiguration
{
    public interface IBooksService
    {
        ValueTask<IEnumerable<Book>> GetBooksAsync();
    }
}