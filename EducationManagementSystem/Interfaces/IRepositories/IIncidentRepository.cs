using EducationManagementSystem.Models;

namespace EducationManagementSystem.Interfaces.IRepositories
{
    public interface IIncidentRepository
    {
        Task<Incident> AddIncidentAsync(Incident model);
        Task<List<Incident>> GetAllAsync();
    }
}
