using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IService;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using EmployeeManagementSystem.Data;

namespace EducationManagementSystem.Services
{
    public class VenueService : IVenueService
    {
        private readonly IVenueRepository _repository;

        public VenueService(IVenueRepository repository)
        {
            _repository = repository;
        }

        public async Task<VenueResponseViewModel> AddVenueAsync(VenueRequestViewModel model)
        {
            var venue = Mapper.MapVenueRequestViewModelToVenue(model);
            var added = await _repository.AddVenueAsync(venue);
            return Mapper.MapVenueToVenueResponseViewModel(added);
        }

        //public async Task<IEnumerable<VenueListViewModel>> GetAllVenuesNoFilterAsync()
        //{
        //    var existingVenues = await _repository.GetAllVenuesNoFilterAsync();
        //    if (existingVenues.Any(v => v.VennueName.Equals(model.VennueName, StringComparison.OrdinalIgnoreCase)))
        //    {
        //        throw new Exception("A venue with this name already exists.");
        //    }
        //}

        public async Task<VenueResponseViewModel> UpdateVenueAsync(Guid Venueid, VenueRequestViewModel model)
        {
            var venue = await _repository.GetVenueByIdAsync(Venueid);
            if (venue == null)
                return null;

            Mapper.MapVenueRequestViewModelToVenue(model);

            var updated = await _repository.UpdateVenueAsync(venue);

            return Mapper.MapVenueToVenueResponseViewModel(updated);
        }

        public async Task<IEnumerable<VenueListViewModel>> GetAllVenuesAsync(string? searchTerm)
        {
            var venues = await _repository.GetAllVenuesAsync();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                venues = venues.Where(v =>
                    v.VennueName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    v.PostCode.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                );
            }
            return venues.Select(Mapper.MapVenueToVenueListViewModel).ToList();
        }
    }
}
