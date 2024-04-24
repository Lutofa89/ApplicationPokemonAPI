namespace ApplicationPokemonAPI.Util
{
    public class PokemonUtil
    {
        public const string Pokeball = "icons8-pokeball-96.png";

        public const string Greatball = "icons8-superball-96.png";

        public const string Ultraball = "icons8-ultra-ball-96.png";

        public const string MasterBall = "icons8-mega-ball-96.png";

        public static string GetRandomBall()
        {
            var pokeballArray = new String[] { Pokeball, Greatball, Ultraball, MasterBall };

            var rand = new Random();
            string randomball = pokeballArray[rand.Next(pokeballArray.Length)];

            return randomball;
        }

        public static double GetPokemonHeightInMeters(int height)
        {
            return Convert.ToDouble(height) / 10;
        }

        public static double GetPokemonWeightInKilograms(int weight)
        {
            return Convert.ToDouble(weight) / 10;
        }
    }




}
}
