using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGo.RocketAPI.Business.Models;
using PokemonGo.RocketAPI.Data;
using PokemonGo.RocketAPI.Entities;
using System.Net;
using Newtonsoft.Json;

namespace PokemonGo.RocketAPI.Business.Implementation
{
    public class PokemonManager : IPokemonManager
    {
        public Task AddCapture(string name, double latitude, double longitude, double cp, string email, double earnedXp)
        {
            return Task.Run(() =>
            {
                using (var ctx = new PokemonContext())
                {
                    var capture = new Capture()
                    {
                        Pokemon = ctx.Pokemon.FirstOrDefault(x => x.Name == name),
                        User = ctx.User.FirstOrDefault(x => x.Email == email),
                        CaptureTime = DateTime.UtcNow,
                        EarnedXp = earnedXp,
                        Latitude = latitude,
                        Longitude = longitude,
                        CP = cp
                    };
                    ctx.Caputre.Add(capture);
                    ctx.SaveChanges();
                }
            });
        }

        public Task AddPokeStop(string identifier, string name, double latitude, double longitude, string email, double earnedXp)
        {
            return Task.Run(() =>
            {
                using (var ctx = new PokemonContext())
                {
                    var pokeStop = ctx.Pokestop.FirstOrDefault(x => x.Identifier == identifier);
                    if (pokeStop == null)
                    {
                        pokeStop = new Pokestop()
                        {
                            Identifier = identifier,
                            Name = name,
                            Latitude = latitude,
                            Longitude = longitude
                        };
                        ctx.Pokestop.Add(pokeStop);
                    }

                    var checkin = new Checkin()
                    {
                        User = ctx.User.FirstOrDefault(x => x.Email == email),
                        CheckinTime = DateTime.UtcNow,
                        EarnedXp = earnedXp,
                        Pokestop = pokeStop
                    };
                    ctx.Checkin.Add(checkin);
                    ctx.SaveChanges();
                }
            });
        }

        public Task AddUser(string email)
        {
            return Task.Run(() =>
            {
                using (var ctx = new PokemonContext())
                {
                    var user = ctx.User.FirstOrDefault(x => x.Email == email);
                    if (user == null)
                    {
                        user = new User()
                        {
                            Email = email
                        };
                        ctx.User.Add(user);
                        ctx.SaveChanges();
                    }
                }
            });
        }

        public Task<PokeApi> GetPokemon(int index)
        {
            return Task.Run(() =>
            {
                var url = "http://pokeapi.co/api/v2/pokemon/{0}/";
                var client = new WebClient { Encoding = System.Text.Encoding.UTF8 };
                var result = client.DownloadString(string.Format(url, index));
                var jss = JsonConvert.DeserializeObject<PokeApi>(result);
                return jss;
            });
        }

        public Task PopulatePokedex()
        {
            return Task.Run(() =>
            {
                for (int i = 1; i < 150; i++)
                {
                    using (var ctx = new PokemonContext())
                    {
                        PokeApi pokeApi = GetPokemon(i).Result;
                        var poke = new Pokemon()
                        {
                            Name = pokeApi.name,
                            PokedexNumber = i,
                            ImageUrl = pokeApi.sprites.front_default
                        };
                        ctx.Pokemon.Add(poke);
                        ctx.SaveChanges();
                        Console.WriteLine("Pokemon " + pokeApi.name + " adicionado!");
                    }
                }
            });
        }
    }
}
