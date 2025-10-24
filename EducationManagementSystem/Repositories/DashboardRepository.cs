using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Lesson> GetTodayLessons()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            return _context.Lessons
                .Include(l => l.Subject)
                .Include(l => l.Student)
                .Include(l => l.Tutor)
                .Where(l => l.DateofLesson == today)
                .ToList();
        }

        public DashboardSummaryViewModel GetDashboardSummary()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var startOfWeek = DateOnly.FromDateTime(DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek));
            var startOfMonth = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, 1);

            return new DashboardSummaryViewModel
            {

                SessionsWaitingApproval = _context.Lessons
                    .Count(s => s.IsApproved == false),

                IncidentsThisWeek = _context.Incidents
                    .Count(i => i.Date >= startOfWeek && i.Date <= today),

                IncidentsThisMonth = _context.Incidents
                    .Count(i => i.Date >= startOfMonth && i.Date <= today),

                PlannedSessions = _context.Lessons
                    .Count(s => s.Attendance == AttendanceStatus.Planned
                        && s.DateofLesson >= startOfWeek && s.DateofLesson <= today),

                CompletedSessions = _context.Lessons
                    .Count(s => s.Attendance == AttendanceStatus.Completed
                        && s.DateofLesson >= startOfWeek && s.DateofLesson <= today),

                NotAttendedSessions = _context.Lessons
                    .Count(s => s.Attendance == AttendanceStatus.NotAttended
                        && s.DateofLesson >= startOfWeek && s.DateofLesson <= today)
            };
        }
    }
}
