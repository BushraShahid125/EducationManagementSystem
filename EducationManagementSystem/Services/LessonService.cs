using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _repo;

        public LessonService(ILessonRepository repo)
        {
            _repo = repo;
        }

        public async Task<LessonResponseViewModel> CreateAsync(LessonRequestViewModel model)
        {

            var allLessons = await _repo.GetAllAsync();

            bool conflict = allLessons.Any(l =>
                l.DateofLesson == model.DateOfLesson &&  
                l.StartTime == model.StartTime &&         
                (l.StudentId == model.StudentId || l.TutorId == model.TutorId) 
            );

            if (conflict)
                return null;

            var lesson = Mapper.MapLessonRequestToLesson(model);
            var created = await _repo.AddAsync(lesson);
            return Mapper.MapLessonToResponse(created);
        }

        public async Task<LessonResponseViewModel> GetByIdAsync(int lessonId)
        {
            var lesson = await _repo.GetByIdAsync(lessonId);
            return Mapper.MapLessonToResponse(lesson);
        }

        public async Task<IEnumerable<LessonResponseViewModel>> GetAllAsync()
        {
            var lessons = await _repo.GetAllAsync();
            return lessons.Select(Mapper.MapLessonToResponse);
        }

        public async Task<LessonResponseViewModel?> UpdateAsync(int lessonId, LessonUpdateViewModel model)
        {
            var lesson = await _repo.GetByIdAsync(lessonId);
            if (lesson == null) 
                return null;

            Mapper.MapLessonUpdateToLesson(model, lesson);
            var updated = await _repo.UpdateAsync(lesson);
            return Mapper.MapLessonToResponse(updated);
        }

        //   Attendance

        public async Task<AttendanceResponseViewModel> AddAsync(AttendanceRequestViewModel model)
        {
            var lesson = await _repo.GetByIdAsync(model.LessonId);
            if (lesson == null)
                return null;
            Mapper.MapAttendanceRequestToLesson(model, lesson);
            var updated = await _repo.UpdateAttendanceAsync(lesson);
            return Mapper.MapLessonToAttendanceResponse(updated);
        }

        public async Task<AttendanceResponseViewModel?> UpdateAsync(int lessonId, AttendanceUpdateViewModel model)
        {
            var lesson = await _repo.GetByIdAsync(lessonId);
            if (lesson == null)
                return null;

            Mapper.MapAttendanceUpdateToLesson(model, lesson);
            var updated = await _repo.UpdateAsync(lesson);
            return Mapper.MapLessonToAttendanceResponse(updated);
        }

        public async Task<AttendanceResponseViewModel?> GetByLessonIdAsync(int lessonId)
        {
            var lesson = await _repo.GetByIdAsync(lessonId);
            return Mapper.MapLessonToAttendanceResponse(lesson);
        }


    }
}
