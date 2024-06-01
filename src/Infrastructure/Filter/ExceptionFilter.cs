using CSharpCleanArch.Domain.Exceptions;
using CSharpCleanArch.Infrastructure.Presenters;

using Microsoft.AspNetCore.Mvc.Filters;

namespace CSharpCleanArch.Infrastructure.Filter;
public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is DomainException)
        {
            var exception = context.Exception as DomainException;
            var result = new ResponseException(exception!);
            context.Result = result;
            return;
        }

        context.Result =
            new ResponseException(
                new DomainException(
                    context.Exception.Message,
                    "Error interno no servidor",
                    StatusCodes.Status500InternalServerError
                )
            );
    }
}