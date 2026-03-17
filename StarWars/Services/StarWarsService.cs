using StarWars.Api;
using StarWars.Mapeo;
using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services
{
    public class StarWarsService
    {
        private readonly HttpClient _httpClient;

        public StarWarsService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri("https://swapi.dev/api/");
        }

        // Método para obtener la lista de personajes
        public async Task<List<Persona>> GetPersonajesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<PeopleResponse<Persona>>("people/");
            return response?.results ?? new List<Persona>();
        }
    }
}
