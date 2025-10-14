using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _incidentRepository;

        public IncidentService(IIncidentRepository incidentrepository)
        {
            _incidentRepository = incidentrepository;
        }

        public async Task<IncidentResponseViewModel> AddIncidentAsync(IncidentRequestViewModel model)
        {
            var incident = Mapper.MapIncidentRequestViewModelToIncident(model);
            await _incidentRepository.AddIncidentAsync(incident);
            return Mapper.MapIncidentToIncidentResponseViewModel(incident);
        }

        public async Task<PagedIncidentListResponse> GetIncidentsAsync(IncidentSearchRequestViewModel request)
        {
            var allIncidents = await _incidentRepository.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var search = request.Search.ToLower();
                allIncidents = allIncidents.Where(i =>
                    i.IncidentTitle.ToLower().Contains(search) ||
                    (i.Tutor.FirstName + " " + i.Tutor.LastName).ToLower().Contains(search) ||
                    (i.Student.FirstName + " " + i.Student.LastName).ToLower().Contains(search)
                ).ToList();
            }

            var totalCount = allIncidents.Count;
            var pagedIncidents = allIncidents
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var list = pagedIncidents.Select(Mapper.MapIncidentToIncidentListViewModel).ToList();

            return new PagedIncidentListResponse
            {
                Items = list,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }

    }
}