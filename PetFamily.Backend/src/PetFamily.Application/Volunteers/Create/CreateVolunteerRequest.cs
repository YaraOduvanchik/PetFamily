using FluentValidation;
using PetFamily.Application.SharedValidators;
using PetFamily.Domain.Shared;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Application.Volunteers.Create;

public record CreateVolunteerRequest(
    string Name,
    string Surname,
    string Patronymic,
    string PhoneNumber,
    string Description,
    int ExperienceInYears);

public class VolunteerValidation : AbstractValidator<CreateVolunteerRequest>
{
    public VolunteerValidation()
    {
        RuleFor(v => v.PhoneNumber)
            .MustBeValueObject(PhoneNumber.Create);
        
        RuleFor(x => new { x.Name, x.Surname, x.Patronymic })
            .MustBeValueObject(x => Fullname.Create(x.Name, x.Surname, x.Patronymic));
        
        RuleFor(v => v.Name)
            .NotEmpty()
            .MaximumLength(Constraints.SHORT_LENGTH);
        
        RuleFor(v => v.Surname)
            .NotEmpty()
            .MaximumLength(Constraints.SHORT_LENGTH);
        
        RuleFor(v => v.Patronymic)
            .NotEmpty()
            .MaximumLength(Constraints.SHORT_LENGTH);;
        
        RuleFor(v => v.Description)
            .NotEmpty()
            .MaximumLength(Constraints.LONG_LENGTH);;
        
        RuleFor(v => v.ExperienceInYears)
            .NotEmpty();
    }
}