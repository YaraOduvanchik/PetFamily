using CSharpFunctionalExtensions;
using PetFamily.Domain.Entities.Volunteers;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers;

public interface IVolunteerRepository
{
    Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken);
}