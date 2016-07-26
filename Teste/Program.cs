using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGo.RocketAPI.Business.Implementation;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            PokemonManager manager = new PokemonManager();

            manager.PopulatePokedex().Wait() ;

        }
    }
}
