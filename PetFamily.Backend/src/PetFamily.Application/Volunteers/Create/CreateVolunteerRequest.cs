namespace PetFamily.Application.Volunteers.Create;

public record CreateVolunteerRequest(
    string Name,
    string Surname,
    string Patronymic,
    string PhoneNumber,
    string Description,
    int ExperienceInYears);