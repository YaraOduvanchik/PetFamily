using FluentValidation;
using PetFamily.Domain.Shared.Ids;

namespace PetFamily.Application.Volunteers.Update.Requisites;

public record UpdateRequisitesRequest(VolunteerId VolunteerId, UpdateRequisitesDto Dto);

public class UpdateRequisitesRequestValidator : AbstractValidator<UpdateRequisitesRequest>
{
    public UpdateRequisitesRequestValidator()
    {
        RuleFor(v => v.VolunteerId).NotEmpty();
    }
}