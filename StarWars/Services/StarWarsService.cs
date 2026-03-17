using StarWars.Api;
using StarWars.Mapeo;
using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace StarWars.Services
{
    public class StarWarsService
    {
        private readonly HttpClient _httpClient;

        public StarWarsService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://swapi.dev/api/");
        }

        public async Task<List<Persona>> GetPersonajesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<PeopleResponse<PersonajeSW>>("people/");

            if (response == null)
                return new List<Persona>();

            return response.results
                .Select(x => PersonaM.Map(x))
                .ToList();
        }
    }
}