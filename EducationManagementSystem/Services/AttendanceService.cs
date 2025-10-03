using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using EducationManagementSystem.Common;

namespace EducationManagementSystem.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _repo;

        public AttendanceService(IAttendanceRepository repo)
        {
            _repo = repo;
        }

        public async Task<AttendanceResponseViewModel> AddAsync(AttendanceRequestViewModel model)
        {
            var lesson = await _repo.GetByLessonIdAsync(model.LessonId);
            if (lesson == null) 
                return null;
            Mapper.MapAttendanceRequestToLesson(model , lesson);
            var created = await _repo.AddAsync(lesson);
            return Mapper.MapLessonToAttendanceResponse(created);
        }

        public async Task<AttendanceResponseViewModel?> UpdateAsync(int lessonId, AttendanceUpdateViewModel model)
        {
            var lesson = await _repo.GetByLessonIdAsync(lessonId);
            if (lesson == null) 
                return null;

            Mapper.MapAttendanceUpdateToLesson(model, lesson);
            var updated = await _repo.UpdateAsync(lesson);

            return Mapper.MapLessonToAttendanceResponse(updated);
        }

        public async Task<AttendanceResponseViewModel?> GetByLessonIdAsync(int lessonId)
        {
            var lesson = await _repo.GetByLessonIdAsync(lessonId);
            return Mapper.MapLessonToAttendanceResponse(lesson);
        }
    }
}
