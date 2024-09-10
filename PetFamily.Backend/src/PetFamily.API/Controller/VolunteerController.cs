using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetFamily.Application.Volunteers.Create;
using PetFamily.Application.Volunteers.Update.MainInfo;
using PetFamily.Application.Volunteers.Update.SocialNetworks;
using PetFamily.Domain.Shared.Ids;

namespace PetFamily.API.Controller;

public class VolunteerController : ApplicationController
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateVolunteerHandler handler,
        [FromBody] CreateVolunteerRequest request,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(request, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpPut("{id:guid}/main-info")]
    public async Task<IActionResult> UpdateMainInfo(
        [FromRoute] Guid id,
        [FromServices] UpdateMainInfoHandler handler,
        [FromBody] UpdateMainInfoDto dto,
        [FromServices] IValidator<UpdateMainInfoRequest> validator,
        CancellationToken cancellationToken)
    {
        var request = new UpdateMainInfoRequest(VolunteerId.Create(id), dto);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid == false)
            return BadRequest(validationResult.Errors);

        var result = await handler.Handle(request, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpPut("{id:guid}/upload-social-networks")]
    public async Task<IActionResult> UpdateSocialNetworks(
        [FromRoute] Guid id,
        [FromServices] UpdateSocialNetworksHandler handler,
        [FromBody] UpdateSocialNetworksDto dto,
        [FromServices] IValidator<UpdateSocialNetworksRequest> validator,
        CancellationToken cancellationToken)
    {
        var request = new UpdateSocialNetworksRequest(VolunteerId.Create(id), dto);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid == false)
            return BadRequest(validationResult.Errors);

        var result = await handler.Handle(request, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result);
    }
}