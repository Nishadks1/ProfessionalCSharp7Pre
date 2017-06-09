using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formula1.Services;

namespace Formula1Services.Controllers
{
    [Route("api/[controller]")]
    public class Formula1Controller : Controller
    {
        private readonly Formula1QueryServices _formula1Services;

        public Formula1Controller(Formula1QueryServices formula1Services)
        {
            _formula1Services = formula1Services;
        }

        [HttpGet("years")]
        public IEnumerable<int> GetYears()
        {
            return _formula1Services.GetYears();
        }

        [HttpGet("{year}/races")]
        public IEnumerable<(DateTime date, string country)> GetRaces(int year)
        {
            return _formula1Services.GetRaces(year);
        }

        [HttpGet("race/{year}/{month}/{day}")]
        public IEnumerable<(int position, string racer, string team)> GetResults(int year, int month, int day)
        {
            return _formula1Services.GetResults(new DateTime(year, month, day));
        }

      
    }
}
