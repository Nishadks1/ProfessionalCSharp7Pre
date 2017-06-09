using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Formula1Context : DbContext
    {
        public Formula1Context(DbContextOptions<Formula1Context> options)
            : base(options)
        {

        }
        public virtual DbSet<Circuit> Circuits { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<RaceResult> RaceResults { get; set; }
        public virtual DbSet<Racer> Racers { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
    }
}
