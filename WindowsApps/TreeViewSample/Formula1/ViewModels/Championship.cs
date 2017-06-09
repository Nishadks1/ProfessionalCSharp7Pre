using Formula1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.ViewModels
{
    public class Championship
    {
        private readonly Formula1Context _context;
        public Championship(Formula1Context context)
        {
            _context = context;
        }
        public int Year { get; set; }

        public override string ToString() => Year.ToString();

        // missing: expression tree support for tuples
        // https://github.com/dotnet/roslyn/issues/12897
        private IEnumerable<(DateTime Date, string Country)> GetRaces()
        {
            IEnumerable<Race> races =
                _context.Races
                .Where(r => r.Date.Year == Year)
                .OrderBy(r => r.Date).ToList();

            return races.Select(r =>
            {
                return (Date: r.Date, Country: r.Circuit.Country);
            }).ToList();
        }
    }    
}
