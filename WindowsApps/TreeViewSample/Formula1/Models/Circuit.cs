using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Circuit
    {
        public Circuit()
        {
            Races = new HashSet<Race>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Race> Races { get; }
    }
}
