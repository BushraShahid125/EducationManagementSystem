using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Interfaces.IServices
{
    public interface IDashboardService
    {
        DashboardSummaryViewModel GetDashboardSummary();
        List<TodayLessonViewModel> GetTodayLessons();
    }
}
