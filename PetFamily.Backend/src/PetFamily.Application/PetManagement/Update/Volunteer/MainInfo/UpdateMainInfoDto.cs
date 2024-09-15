using FluentValidation;
using PetFamily.Application.SharedValidators;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Application.Volunteers.Update.MainInfo;

public record UpdateMainInfoDto(
    FullnameDto FullName,
    string PhoneNumber,
    string Descriptions,
    int ExperienceInYears);

public record FullnameDto(
    string Name,
    string Surname,
    string Patronymic);

public class UploadMainInfoDtoValidator : AbstractValidator<UpdateMainInfoDto>
{
    public UploadMainInfoDtoValidator()
    {
        RuleFor(d => d.FullName)
            .MustBeValueObject(f =>
                Fullname.Create(f.Name, f.Surname, f.Patronymic));

        RuleFor(d => d.PhoneNumber)
            .MustBeValueObject(PhoneNumber.Create);

        RuleFor(d => d.Descriptions)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.LONG_LENGTH);

        RuleFor(d => d.ExperienceInYears)
            .GreaterThanWithError(0);
    }
}