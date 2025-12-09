using GeradorResumo.Application.DTOs;
using GeradorResumo.Application.Execeptions;
using GeradorResumo.Domain.Services;

namespace GeradorResumo.Application.UseCases
{
    public class SumarryIAUseCase : ISumarryIAUseCase
    {

        private readonly ISummaryIA _summaryIA;

        public SumarryIAUseCase(ISummaryIA summaryIA)
        {
            _summaryIA = summaryIA;
        }

        public async Task<SummaryResponse> Execute(string text)
        {
            ValidateUseCase(text);

            var response = await _summaryIA.SummaryAsync(text);

            return new SummaryResponse
            {
                text = response
            };
        }


        public void ValidateUseCase(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new GeradorResumoException("Por favor, escreva um texto maior para que eu possa gerar um resumo.");
            }

            if (text.Length > 20000)
            {
                throw new GeradorResumoException("Texto muito grande para gerar resumo.");
            }
        }
    }
}
