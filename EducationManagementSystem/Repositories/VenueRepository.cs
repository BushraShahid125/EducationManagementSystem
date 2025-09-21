using EducationManagementSystem.Models;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationManagementSystem.Repositories
{
    public class VenueRepository : IVenueRepository
    {
        private readonly ApplicationDbContext _context;

        public VenueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Venue> AddVenueAsync(Venue venue)
        {
            _context.Venues.Add(venue);
            await _context.SaveChangesAsync();
            return venue;
        }
        public async Task<IEnumerable<Venue>> GetAllVenuesNoFilterAsync()
        {
            return await _context.Venues.ToListAsync();
        }

        public async Task<Venue> GetVenueByIdAsync(Guid id) 
        {
            return await _context.Venues.FindAsync(id);
        }

        public async Task<Venue> UpdateVenueAsync(Venue venue)
        {
            _context.Venues.Update(venue);
            await _context.SaveChangesAsync();
            return venue;
        }

        public async Task<IEnumerable<Venue>> GetAllVenuesAsync(string? name = null, string? postCode = null)
        {
            var query = _context.Venues.AsQueryable();
            return await query.ToListAsync();
        }
    }

}
