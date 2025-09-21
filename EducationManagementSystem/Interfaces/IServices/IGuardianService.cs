using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Interfaces.IServices
{
    public interface IGuardianService
    {
        Task<GuardianResponseViewModel> AddGuardianAsync(GuardianRequestViewModel model);
        Task<GuardianResponseViewModel> EditGuardianAsync(string Guardianid, GuardianUpdateViewModel model);
        Task<List<GuardianListViewModel>> GetGuardianListAsync();
    }
}