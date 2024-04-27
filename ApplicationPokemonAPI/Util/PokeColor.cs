namespace ApplicationPokemonAPI.Util
{
    public static class PokeColor
    {
        public static string GetTypeColor(string type)
        {
            string color = type switch
            {
                "bug" => "green",
                "dragon" => "#ffeaa7",
                "electric" => "#fed330",
                "fairy" => "#ff0069",
                "fighting" => "#30336b",
                "fire" => "#f0932b",
                "flying" => "#81ecec",
                "grass" => "#00b894",
                "ground" => "#efb549",
                "ghost" => "#a55eea",
                "ice" => "#74b9ff",
                "normal" => "#95afc0",
                "poison" => "#6c5ce7",
                "psychic" => "#a29bfe",
                "rock" => "#2d3436",
                "water" => "#0190ff",
                _ => "#0190ff"
            };

            return color;
        }

        public static string GetColor(string stat)
        {

            string colort = stat switch
            {
                "hp" => "#feoooo",
                "attack" => "#ee7f30",
                "defense" => "#f7d02c",
                "special-attack" => "#f85687",
                "special-defense" => "#77c755",
                "speed" => "#678fee",
                _ => "#190ff"
            };
            return colort;


        }



    }
}
