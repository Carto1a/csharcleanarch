using CSharpCleanArch.Domain.Exceptions;

using Microsoft.AspNetCore.Mvc;

namespace CSharpCleanArch.Infrastructure.Presenters;
public class ResponseException : IActionResult
{
    private List<string> Errors { get; set; }
    private int StatusCode { get; set; }

    public ResponseException(DomainException exception)
    {
        Errors = exception.Errors;
        StatusCode = exception.StatusCode;
    }

    public Task ExecuteResultAsync(ActionContext context)
    {
        var ResposeData =
            new ObjectResult(new ResponseObject(null, Errors))
            {
                StatusCode = StatusCode,
            };

        return ResposeData.ExecuteResultAsync(context);
    }
}