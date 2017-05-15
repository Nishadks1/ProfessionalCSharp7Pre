using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionWithConfiguration
{
    public class BooksFileServiceOptions
    {
        public string FileName { get; set; }
    }

    public class BooksFileService : IBooksService
    {
        private readonly string _fileName;

        public BooksFileService(IOptions<BooksFileServiceOptions> booksServiceOptions)
        {
            _fileName = booksServiceOptions.Value.FileName;
        }
        public async ValueTask<IEnumerable<Book>> GetBooksAsync()
        {
            string json = await File.ReadAllTextAsync(_fileName);
            return JsonConvert.DeserializeObject<IEnumerable<Book>>(json);
        }
    }

    public static class BooksFileServiceExtensions
    {
        public static IServiceCollection AddBooksService(this IServiceCollection collection,
            IConfiguration configuration)
        {
            if (collection is null) throw new ArgumentNullException(nameof(collection));
            if (configuration is null) throw new ArgumentNullException(nameof(configuration));

            collection.Configure<BooksFileServiceOptions>(configuration);
            return collection.AddSingleton<IBooksService, BooksFileService>();
        }
    }
}
