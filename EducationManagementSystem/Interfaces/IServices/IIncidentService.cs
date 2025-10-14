using EducationManagementSystem.Services;
using EducationManagementSystem.ViewModels;
namespace EducationManagementSystem.Interfaces.IServices
{
    public interface IIncidentService
    {
        Task<IncidentResponseViewModel> AddIncidentAsync(IncidentRequestViewModel model);
        Task<PagedIncidentListResponse> GetIncidentsAsync(IncidentSearchRequestViewModel request);
    }
}
