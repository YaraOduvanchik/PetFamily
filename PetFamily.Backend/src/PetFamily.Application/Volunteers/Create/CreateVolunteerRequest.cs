using FluentValidation;
using PetFamily.Application.Dtos;
using PetFamily.Application.SharedValidators;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Application.Volunteers.Create;

public record CreateVolunteerRequest(
    FullNameDto FullName,
    string PhoneNumber,
    string Description,
    int ExperienceInYears);

public class VolunteerValidation : AbstractValidator<CreateVolunteerRequest>
{
    public VolunteerValidation()
    {
        RuleFor(v => v.FullName)
            .MustBeValueObject(x => Fullname.Create(x.Name, x.Surname, x.Patronymic));

        RuleFor(v => v.PhoneNumber)
            .MustBeValueObject(PhoneNumber.Create);

        RuleFor(v => v.Description)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.LONG_LENGTH);

        RuleFor(v => v.ExperienceInYears)
            .NotEmptyWithError();
    }
}