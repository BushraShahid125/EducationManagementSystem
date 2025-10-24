using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Services
{
    public class LessonNoteService : ILessonNoteService
    {
        private readonly ILessonNoteRepository _noteRepo;
        private readonly ILessonRepository _lessonRepo;

        public LessonNoteService(ILessonNoteRepository noteRepo, ILessonRepository lessonRepo)
        {
            _noteRepo = noteRepo;
            _lessonRepo = lessonRepo;
        }

        public async Task<LessonNoteResponseViewModel> AddAsync(LessonNoteRequestViewModel model)
        {
            var lesson = await _lessonRepo.GetByIdAsync(model.LessonId);
            if (lesson == null)
                return null;

            var note = Mapper.MapLessonNoteRequestViewModelToLessonNote(model);
            note.LessonId = model.LessonId; 

            var created = await _noteRepo.AddAsync(note);
            return Mapper.MapLessonNoteToLessonNoteResponseViewModel(created);
        }

        public async Task<LessonNoteResponseViewModel> UpdateAsync(int lessonId, LessonNoteUpdateViewModel model)
        {
            var existingNote = await _noteRepo.GetByLessonIdAsync(lessonId);
            if (existingNote == null)
                return null;
            Mapper.MapLessonNoteUpdateViewModelToLessonNote(model , existingNote);
            var updated = await _noteRepo.UpdateAsync(existingNote);
            return Mapper.MapLessonNoteToLessonNoteResponseViewModel(updated);
        }

        public async Task<LessonNoteResponseViewModel> GetByLessonIdAsync(int lessonId)
        {
            var note = await _noteRepo.GetByLessonIdAsync(lessonId);
            return Mapper.MapLessonNoteToLessonNoteResponseViewModel(note);
        }
    }
}
