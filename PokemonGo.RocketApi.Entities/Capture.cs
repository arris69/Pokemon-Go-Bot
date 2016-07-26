using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGo.RocketAPI.Entities
{
    public class Capture
    {
        public int CaptureId { get; set; }

        public double EarnedXp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double CP { get; set; }
        public DateTime CaptureTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
