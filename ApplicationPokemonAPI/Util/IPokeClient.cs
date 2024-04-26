using ApplicationPokemonAPI.Models;

namespace ApplicationPokemonAPI.Util
{
    public class IPokeClient
    {

        HttpClient Client { get; set; }

        Task DeletePokemon(int pokemonId);
        Task<List<Pokemon>> GetFavoritePokemon();
        Task<Pokemon> GetPokemon(string id);
        Task ToggleFavoritePokemon(int pokemonId, bool isFavorite);
        Task UpdatePokemon(Pokemon pokemon);


    }
}
