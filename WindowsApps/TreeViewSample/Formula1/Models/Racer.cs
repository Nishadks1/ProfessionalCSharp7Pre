using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Racer
    {
        public Racer()
        {
            RaceResults = new HashSet<RaceResult>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public int? Starts { get; set; }
        public int? Wins { get; set; }

        public virtual ICollection<RaceResult> RaceResults { get; }
    }
}
