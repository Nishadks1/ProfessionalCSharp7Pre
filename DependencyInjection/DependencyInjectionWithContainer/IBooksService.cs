using System.Collections.Generic;
using System.Threading.Tasks;

namespace DependencyInjectionWithContainer
{
    public interface IBooksService
    {
        ValueTask<IEnumerable<Book>> GetBooksAsync();
    }
}