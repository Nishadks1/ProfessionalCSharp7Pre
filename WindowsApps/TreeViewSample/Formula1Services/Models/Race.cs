using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Formula1.Models
{
    public class Race
    {
        public Race()
        {
            this.RaceResults = new HashSet<RaceResult>();
        }

        public int Id { get; set; }

        public int CircuitId { get; set; }
        public DateTime Date { get; set; }

        public Circuit Circuit { get; set; }
        public ICollection<RaceResult> RaceResults { get; }
    }
}
