using FluentValidation;
using PetFamily.Domain.Shared.Ids;

namespace PetFamily.Application.Volunteers.Update.SocialNetworks;

public record UpdateSocialNetworksRequest(VolunteerId Id, UpdateSocialNetworksDto Dto);

public class UpdateSocialNetworksRequestValidator : AbstractValidator<UpdateSocialNetworksRequest>
{
    public UpdateSocialNetworksRequestValidator()
    {
        RuleFor(request => request.Id).NotNull();
    }
}