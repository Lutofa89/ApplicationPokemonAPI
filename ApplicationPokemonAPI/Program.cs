using ApplicationPokemonAPI.Util;// j'ai ajouté un using (Util) qui fait le lien avec le dossier Util et le fichier PokeClient.cs
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ApplicationPokemonAPI; // 

namespace ApplicationPokemonAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<PokeClient>();

            await builder.Build().RunAsync();
        }
    }
}
