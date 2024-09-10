using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Aggregates.PetsManagement.AggregateRoot;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.Ids;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Application.Volunteers.Create;

public class CreateVolunteerHandler
{
    private readonly IVolunteerRepository _repository;
    private readonly ILogger<CreateVolunteerHandler> _logger;

    public CreateVolunteerHandler(IVolunteerRepository repository, ILogger<CreateVolunteerHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(CreateVolunteerRequest request, CancellationToken cancellationToken)
    {
        var volunteerId = VolunteerId.NewId();

        var fullNameDto = request.FullName;

        var fullname = Fullname.Create(fullNameDto.Name, fullNameDto.Surname, fullNameDto.Patronymic);

        var phoneNumber = PhoneNumber.Create(request.PhoneNumber);

        var volunteer = Volunteer.Create(
            volunteerId,
            fullname.Value,
            phoneNumber.Value,
            request.Description,
            request.ExperienceInYears);

        if (volunteer.IsFailure)
            return volunteer.Error;

        _logger.LogInformation("Created volunteer with ID: {volunteerId}", volunteerId);

        return await _repository.Add(volunteer.Value, cancellationToken);
    }
}