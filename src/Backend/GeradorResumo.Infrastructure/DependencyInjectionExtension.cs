using GeradorResumo.Domain.Services;
using GeradorResumo.Infrastructure.Services;
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
            AddSummaryIA(service);
        }

        public static void AddGoogleGenAI(IServiceCollection service, IConfiguration configuration)
        {
            var settings = configuration["GoogleGenAI:ApiKey"] ?? Environment.GetEnvironmentVariable("GoogleGenAI:ApiKey");

            if(string.IsNullOrWhiteSpace(settings)) {
                throw new Exception("Falta a chave da API.");
            }

            service.AddSingleton(new Client(apiKey: settings));
        }

        public static void AddSummaryIA(IServiceCollection service)
        {
            service.AddScoped<ISummaryIA, GeminiService>();
        }
    }
}
