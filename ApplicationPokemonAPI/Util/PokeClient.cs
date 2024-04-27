using ApplicationPokemonAPI.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationPokemonAPI.Util
{
    public class PokeClient : IPokeClient
    {

        public HttpClient Client { get; set; }
        public PokeClient(HttpClient client) // c'est le constructeur 
        {
            this.Client = client;
        }

        public PokeClient() // c'est le constructeur 
        { }
        public async Task<Pokemon> GetPokemon(string id)
        {
            var response = await this.Client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<Pokemon>(content, options);
        }
        // Méthode pour marquer un Pokemon comme favori
        public async Task ToggleFavoritePokemon(int pokemonId, bool isFavorite)
        {
            // Création de données JSON à envoyer dans la requête
            var data = new StringContent(JsonSerializer.Serialize(new { PokemonId = pokemonId, IsFavorite = isFavorite }), Encoding.UTF8, "application/json");

            // Envoi d'une requête PUT pour mettre à jour le statut de favori du Pokemon
            var response = await Client.PutAsync($"https://pokeapi.co/api/v2/pokemon/favorite/{pokemonId}", data);
            response.EnsureSuccessStatusCode();
        }

        // Méthode pour supprimer un Pokemon
        public async Task DeletePokemon(int pokemonId)
        {
            // Envoi d'une requête DELETE pour supprimer le Pokemon
            var response = await Client.DeleteAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonId}");
            response.EnsureSuccessStatusCode();
        }

        // Méthode pour mettre à jour un Pokemon
        public async Task UpdatePokemon(Pokemon pokemon)
        {
            // Création de données JSON à envoyer dans la requête
            var data = new StringContent(JsonSerializer.Serialize(pokemon), Encoding.UTF8, "application/json");

            // Envoi d'une requête PUT pour mettre à jour le Pokemon
            var response = await Client.PutAsync($"https://pokeapi.co/api/v2/pokemon/{pokemon.id}", data);
            response.EnsureSuccessStatusCode();
        }

        // Méthode pour récupérer les Pokémon favoris
        public async Task<List<Pokemon>> GetFavoritePokemon()
        {
            var response = await Client.GetAsync("https://pokeapi.co/api/v2/pokemon/favorite");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<Pokemon>>(content, options);
        }
    }
}
