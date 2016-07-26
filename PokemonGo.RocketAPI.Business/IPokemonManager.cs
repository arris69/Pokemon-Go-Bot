using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGo.RocketAPI.Business.Models;

namespace PokemonGo.RocketAPI.Business
{
    public interface IPokemonManager
    {
        Task AddPokeStop(string identifier, string name, double latitude, double longitude, string email, double earnedXp);
        Task AddCapture(string name, double latitude, double longitude, double cp, string email, double earnedXp);
        Task PopulatePokedex();
        Task<PokeApi> GetPokemon(int index);
        Task AddUser(string email);
    }
}
