namespace GeradorResumo.Domain.Services
{
    public interface ISummaryIA
    {
        Task<string> SummaryAsync(string text);      
    }
}
