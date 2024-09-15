using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Application.Volunteers.Update.Requisites;

public class UpdateRequisitesHandler
{
    private readonly IVolunteerRepository _repository;
    private readonly ILogger<UpdateRequisitesHandler> _logger;

    public UpdateRequisitesHandler(
        IVolunteerRepository repository, 
        ILogger<UpdateRequisitesHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(UpdateRequisitesRequest request, CancellationToken cancellationToken)
    {
        var volunteerResult = await _repository.GetById(request.VolunteerId, cancellationToken);
        if (volunteerResult.IsFailure)
            return volunteerResult.Error;

        var requisites = new ValueObjectList<Requisite>(request.Dto.Requests
            .Select(r => Requisite.Create(r.Title, r.Description).Value));
        
        volunteerResult.Value.UploadRequisitesList(requisites);
        
        var result = await _repository.Save(volunteerResult.Value, cancellationToken);

        _logger.LogInformation("Updated social networks from a volunteer with an id: {volunteerResult.Value.Id}",
            volunteerResult.Value.Id);

        return result;
    }
}