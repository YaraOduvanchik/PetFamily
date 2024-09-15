using FluentValidation;
using PetFamily.Application.SharedValidators;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers.Update.SocialNetworks;

public record UpdateSocialNetworksDto(IEnumerable<SocialNetworkDto> SocialNetworks);

public record SocialNetworkDto(string Title, string Link);

public class SocialNetworkDtoValidator : AbstractValidator<SocialNetworkDto>
{
    public SocialNetworkDtoValidator()
    {
        RuleFor(sn => sn.Title)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.SHORT_LENGTH);

        RuleFor(sn => sn.Link)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.MEDIUM_LENGTH);
    }
}

public class UpdateSocialNetworksDtoValidator : AbstractValidator<UpdateSocialNetworksDto>
{
    public UpdateSocialNetworksDtoValidator()
    {
        RuleForEach(dto => dto.SocialNetworks)
            .SetValidator(new SocialNetworkDtoValidator());
    }
}