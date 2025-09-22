using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Common;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Services
{
    public class GuardianService : IGuardianService
    {
        private readonly IGuardianRepository _guardianRepository;

        public GuardianService(IGuardianRepository guardianRepository)
        {
            _guardianRepository = guardianRepository;
        }


        public async Task<GuardianResponseViewModel> AddGuardianAsync(GuardianRequestViewModel model)
        {
            var guardian = Mapper.MapRequestToGuardian(model);
            var added = await _guardianRepository.AddGuardianAsync(guardian);
            return Mapper.MapGuardianToResponseViewModel(added);
        }

        public async Task<GuardianResponseViewModel?> EditGuardianAsync(string Guardianid, GuardianUpdateViewModel model)
        {
            var guardian = await _guardianRepository.GetGuardianByIdAsync(Guardianid);
            if (guardian == null)
                return null;
            Mapper.MapUpdateToGuardian(model, guardian);

            var updatedGuardian = await _guardianRepository.UpdateGuardianAsync(guardian);
            return Mapper.MapGuardianToResponseViewModel(updatedGuardian);
        }

        public async Task<IEnumerable<GuardianListViewModel>> GetGuardianListAsync(string? searchTerm)
        {
            var guardians = await _guardianRepository.GetAllGuardiansAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                guardians = guardians.Where(g =>
                    g.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    g.Students.Any(sg => sg.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                );
            }
            return guardians.Select (Mapper.MapGuardianToGuardianListViewModel).ToList();
        }
    }
}
