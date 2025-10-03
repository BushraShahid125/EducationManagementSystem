using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Services
{
    public class TutorService : ITutorService
    {
        private readonly ITutorRepository _repository;

        public TutorService(ITutorRepository repository)
        {
            _repository = repository;
        }

        public async Task<TutorResponseViewModel> CreateTutorAsync(TutorRequestViewModel model)
        {
            var tutor = Mapper.MapTutorRequestToTutor(model);
            var created = await _repository.CreateAsync(tutor);
            return Mapper.MapTutorToResponse(created);
        }

        public async Task<TutorResponseViewModel> UpdateTutorAsync(String tutorId, TutorUpdateViewModel model)
        {
            var tutor = await _repository.GetByIdAsync(tutorId);
            if (tutor == null) 
                return null;

            Mapper.MapTutorUpdateToTutor(model, tutor);
            var updated = await _repository.UpdateAsync(tutor);
            return Mapper.MapTutorToResponse(updated);
        }

        public async Task<TutorResponseViewModel> GetTutorByIdAsync(string tutorId)
        {
            var tutor = await _repository.GetByIdAsync(tutorId);
            return Mapper.MapTutorToResponse(tutor);
        }

        public async Task<IEnumerable<TutorResponseViewModel>> GetAllTutorsAsync(TutorSearchRequestViewModel filter)
        {
            var tutors = await _repository.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(filter.Name))
                tutors = tutors.Where(t =>
                    t.FirstName.Contains(filter.Name, StringComparison.OrdinalIgnoreCase) ||
                    t.LastName.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(filter.County))
                tutors = tutors.Where(t =>
                    t.County.Contains(filter.County, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(filter.PostCode))
                tutors = tutors.Where(t =>
                    t.PostCode.Contains(filter.PostCode, StringComparison.OrdinalIgnoreCase));

            tutors = tutors
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            return tutors.Select(Mapper.MapTutorToResponse);
        }
    }
}
