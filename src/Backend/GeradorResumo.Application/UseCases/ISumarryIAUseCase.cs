using GeradorResumo.Application.DTOs;

namespace GeradorResumo.Application.UseCases
{
    public interface ISumarryIAUseCase 
    {

        Task<SummaryResponse> Execute(string text);
    }
}
