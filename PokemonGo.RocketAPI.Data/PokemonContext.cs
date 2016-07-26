using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PokemonGo.RocketAPI.Entities;

namespace PokemonGo.RocketAPI.Data
{
    public class PokemonContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Pokestop> Pokestop { get; set; }
        public DbSet<Capture> Caputre { get; set;}
        public DbSet<Checkin> Checkin { get; set; }
    }
}
