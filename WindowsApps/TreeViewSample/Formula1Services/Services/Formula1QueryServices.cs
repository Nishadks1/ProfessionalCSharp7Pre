using Formula1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Formula1.Services
{
    public class Formula1QueryServices
    {
        private readonly Formula1Context _f1Context;
        public Formula1QueryServices(Formula1Context f1Context)
        {
            _f1Context = f1Context;
        }
        public IEnumerable<int> GetYears()
        {
            return _f1Context.Races.Select(r => r.Date.Year).Distinct().ToList();
        }

        public IEnumerable<(DateTime day, string country)> GetRaces(int year)
        {
            IEnumerable<Race> races =
                _f1Context.Races.Include(r => r.Circuit)
                .Where(r => r.Date.Year == year)
                .OrderBy(r => r.Date).ToList();

            return races.Select(r =>
            {
                return (day: r.Date, country: r.Circuit?.Country);
            }).ToList();
        }

        public IEnumerable<(int position, string racer, string team)> GetResults(DateTime day)
        {
            IEnumerable<RaceResult> raceResults = _f1Context.RaceResults
                .Include(rr => rr.Racer).Include(rr => rr.Team)
                .Where(rr => rr.Race.Date == day).ToList();

            return raceResults.Select(rr => 
            (
                position: rr.Position, 
                racer: $"{rr.Racer.FirstName} {rr.Racer.LastName}", 
                car: rr.Team.Name
            ));
        }
    }
}
