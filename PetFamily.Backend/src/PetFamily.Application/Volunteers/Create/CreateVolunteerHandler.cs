using CSharpFunctionalExtensions;
using PetFamily.Domain.Aggregates.PetsManagement.AggregateRoot;
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
        var fullNameDto = request.FullName;
        
        var fullname = Fullname.Create(fullNameDto.Name, fullNameDto.Surname, fullNameDto.Patronymic);

        var phoneNumber = PhoneNumber.Create(request.PhoneNumber);

        var volunteer = Volunteer.Create(
            VolunteerId.NewId(), 
            fullname.Value,
            phoneNumber.Value, 
            request.Description, 
            request.ExperienceInYears);
        
        if (volunteer.IsFailure)
            return volunteer.Error;

        return await _repository.Add(volunteer.Value, cancellationToken);
    }
}