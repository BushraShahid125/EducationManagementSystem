using EducationManagementSystem.ViewModels;

public interface IVenueService
{
    Task<VenueResponseViewModel> AddVenueAsync(VenueRequestViewModel model);
    //Task<IEnumerable<VenueListViewModel>> GetAllVenuesNoFilterAsync(model);
    Task<VenueResponseViewModel> UpdateVenueAsync(Guid id, VenueRequestViewModel model);
    Task<IEnumerable<VenueListViewModel>> GetAllVenuesAsync(string? searchTerm);
}