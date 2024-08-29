using PetFamily.Domain.Aggregates.Volunteers;

namespace PetFamily.Application.Volunteers;

public interface IVolunteerRepository
{
    Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken);
}