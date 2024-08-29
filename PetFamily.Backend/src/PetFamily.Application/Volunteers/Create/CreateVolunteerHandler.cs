using CSharpFunctionalExtensions;
using PetFamily.Domain.Aggregates.Volunteers;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.Ids;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Application.Volunteers.Create;

public class CreateVolunteerHandler
{
    private readonly IVolunteerRepository _repository;

    public CreateVolunteerHandler(IVolunteerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid, Error>> Handle(CreateVolunteerRequest request, CancellationToken cancellationToken)
    {
        var fullname = Fullname.Create(request.Name, request.Surname, request.Patronymic);
        if (fullname.IsFailure)
            return fullname.Error;

        var phoneNumber = PhoneNumber.Create(request.PhoneNumber);
        if (phoneNumber.IsFailure)
            return phoneNumber.Error;

        var volunteer = Volunteer.Create(VolunteerId.NewId(), fullname.Value,
            phoneNumber.Value, request.Description, request.ExperienceInYears);
        if (volunteer.IsFailure)
            return volunteer.Error;

        return await _repository.Add(volunteer.Value, cancellationToken);
    }
}