using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionWithConfiguration
{
    public class Book
    {
        public Book(string title, string publisher)
        {
            Title = title;
            Publisher = publisher;
        }
        public string Title { get; }
        public string Publisher { get; }

        public override string ToString() => Title;
    }
}
