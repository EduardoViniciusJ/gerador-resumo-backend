using GeradorResumo.Application.Execeptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is GeradorResumoException ex)
        {
            var problem = new ProblemDetails
            {
                Status = 400,
                Title = "Erro de validação",
                Detail = ex.Message
            };

            context.Result = new BadRequestObjectResult(problem);
            context.ExceptionHandled = true;
            return;
        }

        var generic = new ProblemDetails
        {
            Status = 500,
            Title = "Erro interno",
            Detail = "Ocorreu um erro inesperado."
        };

        context.Result = new ObjectResult(generic)
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}
