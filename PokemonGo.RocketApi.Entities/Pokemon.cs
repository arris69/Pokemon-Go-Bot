using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGo.RocketAPI.Entities
{
    public class Pokemon
    {
        public int PokemonId { get; set; }

        public int PokedexNumber { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Capture> Captures { get; set; }
    }
}
