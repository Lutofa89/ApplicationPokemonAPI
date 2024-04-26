using ApplicationPokemonAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPokemonAPiTests.Util
{
    public class PokemonUtilTests
    {
        [Fact]
        public void GetRandomBall_Returns_ValidBall()
        {
            // Act
            var result = PokemonUtil.GetRandomBall();

            // Assert
            Assert.Contains(result, new[] { PokemonUtil.Pokeball, PokemonUtil.Greatball, PokemonUtil.Ultraball, PokemonUtil.MasterBall });
        }

        [Theory]
        [InlineData(100, 10.0)]
        [InlineData(50, 5.0)]
        [InlineData(25, 2.5)]
        public void GetPokemonHeightInMeters_Returns_CorrectHeight(int height, double expected)
        {
            // Act
            var result = PokemonUtil.GetPokemonHeightInMeters(height);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100, 10.0)]
        [InlineData(50, 5.0)]
        [InlineData(25, 2.5)]
        public void GetPokemonWeightInKilograms_Returns_CorrectWeight(int weight, double expected)
        {
            // Act
            var result = PokemonUtil.GetPokemonWeightInKilograms(weight);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
