using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Interfaces.IServices
{
    public interface IHomeWorkService
    {
        Task<HomeWorkResponseViewModel> AddHomeWorkAsync(HomeWorkRequestViewModel model);
        Task<IEnumerable<HomeWorkResponseViewModel>> GetHomeWorksAsync();
        Task<HomeWorkResponseViewModel> UpdateHomeWorkAsync(int homeworkid, HomeWorkUpdateViewModel model);
    }
}
