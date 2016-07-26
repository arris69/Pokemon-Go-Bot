using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGo.RocketAPI.Entities
{
    public class Checkin
    {
        public int CheckinId { get; set; }

        public double EarnedXp { get; set; }
        public DateTime CheckinTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PokestopId { get; set; }
        public Pokestop Pokestop { get; set; }
    }
}
