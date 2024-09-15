using FluentValidation;
using Microsoft.AspNetCore.StaticFiles;
using PetFamily.Domain.Shared.Ids;

namespace PetFamily.Application.PetManagement.Delete.Volunteer;

public record DeleteVolunteerRequest(VolunteerId Id);

public class DeleteVolunteerRequestValidator : AbstractValidator<DeleteVolunteerRequest>
{
    public DeleteVolunteerRequestValidator()
    {
        RuleFor(d => d.Id)
            .NotEmpty();
    }
}