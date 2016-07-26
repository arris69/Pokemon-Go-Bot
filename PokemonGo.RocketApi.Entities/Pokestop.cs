using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGo.RocketAPI.Entities
{
    public class Pokestop
    {
        public int PokestopId { get; set; }

        public string Name { get; set; }
        public string Identifier { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<Checkin> Checkins { get; set; }
    }
}
