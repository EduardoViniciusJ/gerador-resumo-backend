using GeradorResumo.Domain.Services;
using Google.GenAI;
using Google.GenAI.Types;
using Microsoft.Extensions.Configuration;
using static Google.Apis.Requests.BatchRequest;

namespace GeradorResumo.Infrastructure.Services
{
    public class GeminiService : ISummaryIA
    {
        private readonly Client _client;
        private readonly string _model;

        public GeminiService(Client client, IConfiguration config)
        {
            _client = client;
            _model = config["GoogleGenAI:Model"]!;
        }

        public async Task<string> SummaryAsync(string text)
        {

            var response = await _client.Models.GenerateContentAsync(
                model: _model,
                contents: $"Resuma o texto abaixo em no máximo 2 linhas, mantendo clareza e objetividade:{text}"

            );


            var summary = ExtractText(response); 

            return summary ?? "Não foi possível gerar um resumo. Tente novamente.";   
        }

        // Checks if properties are null 
        private static string? ExtractText(GenerateContentResponse? response)
        {
            return response?.Candidates?.FirstOrDefault()?
                              .Content?.Parts?.FirstOrDefault()?
                              .Text;
        }
    }
}
