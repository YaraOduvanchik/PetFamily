using PetFamily.Domain.Aggregates.PetsManagement.AggregateRoot;

namespace PetFamily.Application.Volunteers;

public interface IVolunteerRepository
{
    Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken);
}