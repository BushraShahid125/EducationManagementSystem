using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;

public interface IDashboardRepository
{
    DashboardSummaryViewModel GetDashboardSummary();
    public List<Lesson> GetTodayLessons();
}