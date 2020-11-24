using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CalidadZF.Client.Helpers;
using CalidadZF.Client.Repositorios;
using Blazor.FileReader;

namespace CalidadZF.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("CalidadZF.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CalidadZF.ServerAPI"));

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
      
            services.AddScoped<IRepositorio, Repositorio>();
            services.AddScoped<IMostrarMensajes, MostrarMensajes>();
            services.AddAuthorizationCore();

            services.AddSingleton<AppState>();

            services.AddFileReaderService(options => options.InitializeOnFirstCall = true);

        }
    }
}
