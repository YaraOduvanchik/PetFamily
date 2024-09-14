using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Application.Volunteers.Update.MainInfo;

public class UpdateMainInfoHandler
{
    private readonly IVolunteerRepository _volunteerRepository;
    private readonly ILogger<UpdateMainInfoHandler> _logger;

    public UpdateMainInfoHandler(
        IVolunteerRepository volunteerRepository,
        ILogger<UpdateMainInfoHandler> logger)
    {
        _volunteerRepository = volunteerRepository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(UpdateMainInfoRequest request, CancellationToken ct)
    {
        var volunteer = await _volunteerRepository.GetById(request.Id, ct);

        if (volunteer.IsFailure)
            return volunteer.Error;

        var fullnameDto = request.Dto.FullName;
        var fullname = Fullname.Create(
            fullnameDto.Name, fullnameDto.Surname, fullnameDto.Patronymic).Value;

        var phoneNumber = PhoneNumber.Create(request.Dto.PhoneNumber).Value;

        volunteer.Value.UpdateMainInfo(fullname, phoneNumber, request.Dto.Descriptions, request.Dto.ExperienceInYears);

        await _volunteerRepository.Save(volunteer.Value, ct);

        _logger.LogInformation("Updated volunteer with id: {volunteer.Value.Id}", volunteer.Value.Id);

        return volunteer.Value.Id.Value;
    }
}