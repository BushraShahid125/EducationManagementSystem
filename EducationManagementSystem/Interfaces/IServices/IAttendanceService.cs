using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Interfaces.IServices
{
    public interface IAttendanceService
    {
        Task<AttendanceResponseViewModel> AddAsync(AttendanceRequestViewModel model);
        Task<AttendanceResponseViewModel?> UpdateAsync(int lessonId, AttendanceUpdateViewModel model);
        Task<AttendanceResponseViewModel?> GetByLessonIdAsync(int lessonId);
    }
}
