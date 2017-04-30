using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleDI
{
    public interface IBooksService
    {
        ValueTask<IEnumerable<Book>> GetBooksAsync();
    }
}