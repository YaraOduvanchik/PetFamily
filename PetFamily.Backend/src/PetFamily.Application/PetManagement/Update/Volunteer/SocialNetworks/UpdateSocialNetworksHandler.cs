using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Aggregates.PetsManagement.ValueObjects;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Application.Volunteers.Update.SocialNetworks;

public class UpdateSocialNetworksHandler
{
    private readonly IVolunteerRepository _volunteerRepository;
    private readonly ILogger<UpdateSocialNetworksHandler> _logger;

    public UpdateSocialNetworksHandler(
        IVolunteerRepository volunteerRepository,
        ILogger<UpdateSocialNetworksHandler> logger)
    {
        _volunteerRepository = volunteerRepository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(UpdateSocialNetworksRequest request, CancellationToken ct)
    {
        var volunteer = await _volunteerRepository.GetById(request.Id, ct);
        if (volunteer.IsFailure)
            return volunteer.Error;
        
        var socialNetworkList = new ValueObjectList<SocialNetwork>(
            request.Dto.SocialNetworks
                .Select(sn => SocialNetwork.Create(sn.Title, sn.Link).Value));

        volunteer.Value.UploadSocialNetworksList(socialNetworkList);

        var result = await _volunteerRepository.Save(volunteer.Value, ct);

        _logger.LogInformation("Updated social networks from a volunteer with an id: {volunteer.Value.Id}",
            volunteer.Value.Id);

        return result;
    }
}