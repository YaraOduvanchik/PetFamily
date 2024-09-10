using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFamily.Application.Volunteers;
using PetFamily.Domain.Aggregates.PetsManagement.AggregateRoot;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.Ids;

namespace PetFamily.Infrastructure.Repositories;

public class VolunteerRepository : IVolunteerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public VolunteerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Add(Volunteer volunteer, CancellationToken ct)
    {
        await _dbContext.Volunteers.AddAsync(volunteer, ct);
        await _dbContext.SaveChangesAsync(ct);

        return volunteer.Id;
    }

    public async Task<Guid> Save(Volunteer volunteer, CancellationToken ct)
    {
        _dbContext.Volunteers.Attach(volunteer);
        
        await _dbContext.SaveChangesAsync(ct);
        
        return volunteer.Id;
    }

    public async Task<Result<Volunteer, Error>> GetById(VolunteerId id, CancellationToken ct)
    {
        var volunteer = await _dbContext.Volunteers
            .Include(v => v.Pets)
            .ThenInclude(p => p.Photos)
            .FirstOrDefaultAsync(v => v.Id == id, ct);

        if (volunteer is null)
            return Errors.General.NotFound(id);

        return volunteer;
    }
}