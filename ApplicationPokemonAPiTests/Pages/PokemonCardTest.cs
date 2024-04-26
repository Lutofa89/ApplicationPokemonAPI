using ApplicationPokemonAPI.Models;
using ApplicationPokemonAPI.Pages;
using ApplicationPokemonAPI.Util;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Type = ApplicationPokemonAPI.Models.Type;


namespace ApplicationPokemonAPiTests.Pages
{
    public class PokemonPageTests : TestContext
    {
        [Fact]
        public void PokemonPage_RendersCorrectly()
        {
            var pokemon = new Pokemon
            {
                name = "Pikachu",
                types = new List<Type>(),
                height = 50,
                weight = 60,
                stats = new List<Stat>()
            };

            var mockPokeClient = new Mock<IPokeClient>();
            mockPokeClient.Setup(client => client.GetPokemon(It.IsAny<string>()))
              .ReturnsAsync(pokemon);

            using var ctx = new TestContext();
            ctx.Services.AddSingleton(mockPokeClient.Object);


            var component = ctx.RenderComponent<PokemonCard>(
                parameters => parameters.Add(p => p.PokemonId, "1")
            );

            // Act
            var renderedPokemonName = component.Find(".pokemon-name").TextContent;

            // Assert
            Assert.Equal("Pikachu", renderedPokemonName);
        }
    }
}
