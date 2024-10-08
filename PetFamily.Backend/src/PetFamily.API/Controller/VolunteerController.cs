﻿using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetFamily.Application.PetManagement.Delete.Volunteer;
using PetFamily.Application.Volunteers.Create;
using PetFamily.Application.Volunteers.Update.MainInfo;
using PetFamily.Application.Volunteers.Update.Requisites;
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

        return Ok(result.Value);
    }
    
    [HttpPut("{id:guid}/upload-requisites")]
    public async Task<IActionResult> UpdateRequisites(
        [FromRoute] Guid id,
        [FromServices] UpdateRequisitesHandler handler,
        [FromBody] UpdateRequisitesDto dto,
        [FromServices] IValidator<UpdateRequisitesRequest> validator,
        CancellationToken cancellationToken)
    {
        var request = new UpdateRequisitesRequest(VolunteerId.Create(id), dto);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid == false)
            return BadRequest(validationResult.Errors);

        var result = await handler.Handle(request, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid id,
        [FromServices] DeleteVolunteerHandler handler,
        CancellationToken cancellationToken)
    {
        var request = new DeleteVolunteerRequest(id);
        
        var result = await handler.Handle(request, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}