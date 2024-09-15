using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Application.Volunteers;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.PetManagement.Delete.Volunteer;

public class DeleteVolunteerHandler
{
    private readonly IVolunteerRepository _repository;
    private readonly ILogger<DeleteVolunteerHandler> _logger;

    public DeleteVolunteerHandler(
        IVolunteerRepository repository,
        ILogger<DeleteVolunteerHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(DeleteVolunteerRequest request, CancellationToken cancellationToken)
    {
        var volunteerResult = await _repository.GetById(request.Id, cancellationToken);
        if (volunteerResult.IsFailure)
            return volunteerResult.Error;

        return await _repository.Delete(volunteerResult.Value, cancellationToken);
    }
}