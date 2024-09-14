using CSharpFunctionalExtensions;
using PetFamily.Domain.Aggregates.PetsManagement.AggregateRoot;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.Ids;

namespace PetFamily.Application.Volunteers;

public interface IVolunteerRepository
{
    Task<Guid> Add(Volunteer volunteer, CancellationToken ct);
    Task<Guid> Save(Volunteer volunteer, CancellationToken ct);
    Task<Result<Volunteer, Error>> GetById(VolunteerId id, CancellationToken ct);
}