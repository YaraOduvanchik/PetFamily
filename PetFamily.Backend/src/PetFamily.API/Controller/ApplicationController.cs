using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Response;

namespace PetFamily.API.Controller;

[ApiController]
[Route("[controller]")]
public abstract class ApplicationController : ControllerBase
{
    protected new ActionResult Ok(object? result = null)
    {
        var envelope = Envelope.Ok(result);

        return base.Ok(envelope);
    }

    protected IActionResult BadRequest(IEnumerable<ResponseError> errors)
    {
        var envelope = Envelope.Error(errors);

        return base.BadRequest(envelope);
    }

    protected IActionResult NotFound(IEnumerable<ResponseError> errors)
    {
        var envelope = Envelope.Error(errors);

        return base.NotFound(envelope);
    }
}