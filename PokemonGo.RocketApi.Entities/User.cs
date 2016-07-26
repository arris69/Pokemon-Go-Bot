using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGo.RocketAPI.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public ICollection<Checkin> Checkins { get; set; }
        public ICollection<Capture> Captures { get; set; }
    }
}
