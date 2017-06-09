using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Team
    {
        public Team()
        {
            RaceResults = new HashSet<RaceResult>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RaceResult> RaceResults { get; }
    }
}
