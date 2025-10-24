using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.ViewModels;
using EducationManagementSystem.Common;

namespace EducationManagementSystem.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public DashboardSummaryViewModel GetDashboardSummary()
        {
            var summary = _dashboardRepository.GetDashboardSummary();
            return summary;
        }

        public List<TodayLessonViewModel> GetTodayLessons()
        {
            var lessons = _dashboardRepository.GetTodayLessons();
            return lessons.Select(Mapper.MapLessonToTodayLessonViewModel).ToList();
        }
    }
}