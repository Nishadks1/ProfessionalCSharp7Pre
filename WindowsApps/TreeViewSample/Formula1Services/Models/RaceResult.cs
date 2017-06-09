using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class RaceResult
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int Position { get; set; }
        public int? Grid { get; set; }
        public decimal? Points { get; set; }
        public int RacerId { get; set; }
        public int TeamId { get; set; }

        public virtual Race Race { get; set; }
        public virtual Racer Racer { get; set; }
        public virtual Team Team { get; set; }
    }
}
