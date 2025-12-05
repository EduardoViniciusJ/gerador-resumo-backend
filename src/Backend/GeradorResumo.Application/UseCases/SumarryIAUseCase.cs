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

        public async Task<string> Execute(string text)
        {
            ValidateUseCase(text);

            var response = await _summaryIA.SummaryAsync(text);

            return response;
        }


        public void ValidateUseCase(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new GeradorResumoException("Por favor, escreva um texto maior para que eu possa gerar um resumo.");
            }

            if(text.Length > 1)
            {
                throw new GeradorResumoException("Texto muito grande para gerar resumo.");
            }
        }
    }
}
