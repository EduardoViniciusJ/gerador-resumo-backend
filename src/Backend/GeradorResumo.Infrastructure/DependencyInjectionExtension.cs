using Google.GenAI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GeradorResumo.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            AddGoogleGenAI(service, configuration); 
        }

        public static void AddGoogleGenAI(this IServiceCollection service, IConfiguration configuration)
        {
            var settings = configuration["GoogleGenAI:ApiKey"];

            if(string.IsNullOrWhiteSpace(settings)) {
                throw new Exception("falta chave da api");
            }

            service.AddSingleton(new Client(apiKey: settings));
        }
    }
}
