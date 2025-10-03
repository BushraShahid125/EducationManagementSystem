using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Interfaces.IServices
{
    public interface ITutorService
    {
        Task<TutorResponseViewModel> CreateTutorAsync(TutorRequestViewModel model);
        Task<TutorResponseViewModel> UpdateTutorAsync(String tutorId,TutorUpdateViewModel model);
        Task<TutorResponseViewModel> GetTutorByIdAsync(string tutorId);
        Task<IEnumerable<TutorResponseViewModel>> GetAllTutorsAsync(TutorSearchRequestViewModel filter);
    }
}
