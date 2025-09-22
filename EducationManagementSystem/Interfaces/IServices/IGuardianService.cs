using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Interfaces.IServices
{
    public interface IGuardianService
    {
        Task<GuardianResponseViewModel> AddGuardianAsync(GuardianRequestViewModel model);
        Task<GuardianResponseViewModel> EditGuardianAsync(string Guardianid, GuardianUpdateViewModel model);
        Task<IEnumerable<GuardianListViewModel>> GetGuardianListAsync(string? searchTerm);
    }
}