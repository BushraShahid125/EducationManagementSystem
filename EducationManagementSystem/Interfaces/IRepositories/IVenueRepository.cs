using EducationManagementSystem.Models;

public interface IVenueRepository
{
    Task<Venue> AddVenueAsync(Venue venue);
    Task<Venue> UpdateVenueAsync(Venue venue);
    Task<Venue> GetVenueByIdAsync(Guid id);
    Task<IEnumerable<Venue>> GetAllVenuesNoFilterAsync();
    Task<IEnumerable<Venue>> GetAllVenuesAsync();
}
