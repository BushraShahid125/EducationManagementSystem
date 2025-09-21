using EducationManagementSystem.Models;

public interface IVenueRepository
{
    Task<Venue> AddVenueAsync(Venue venue);
    Task<Venue> UpdateVenueAsync(Venue venue);
    Task<Venue> GetVenueByIdAsync(Guid id);
    //Task<Venue> GetAllVenuesNoFilterAsync(Venue venue);
    Task<IEnumerable<Venue>> GetAllVenuesAsync(string? name = null, string? postCode = null);
}
