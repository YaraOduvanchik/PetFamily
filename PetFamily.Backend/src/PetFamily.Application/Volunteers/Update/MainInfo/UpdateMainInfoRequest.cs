using FluentValidation;
using PetFamily.Domain.Shared.Ids;

namespace PetFamily.Application.Volunteers.Update.MainInfo;

public record UpdateMainInfoRequest(
    VolunteerId Id,
    UpdateMainInfoDto Dto);

public class UpdateMainInfoRequestValidator : AbstractValidator<UpdateMainInfoRequest>
{
    public UpdateMainInfoRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}