using FluentValidation;
using PetFamily.Application.SharedValidators;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Application.Volunteers.Update.Requisites;

public record RequisiteDto(string Title, string Description);

public record UpdateRequisitesDto(IEnumerable<RequisiteDto> Requests);

public class RequisiteDtoValidator : AbstractValidator<RequisiteDto>
{
    public RequisiteDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.SHORT_LENGTH);
        
        RuleFor(x => x.Description)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.MEDIUM_LENGTH);
    }
}

public class UpdateRequisitesDtoValidator : AbstractValidator<UpdateRequisitesDto>
{
    public UpdateRequisitesDtoValidator()
    {
        RuleForEach(u => u.Requests)
            .SetValidator(new RequisiteDtoValidator());
    }
}