using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Services
{
    public class TutorService : ITutorService
    {
        private readonly ITutorRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TutorService(ITutorRepository repository, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<TutorResponseViewModel> CreateTutorAsync(TutorRequestViewModel model)
        {
            var tutor = Mapper.MapTutorRequestToTutor(model);

            var result = await _userManager.CreateAsync(tutor, model.Password);

            if (!result.Succeeded)
            {
                return null;
            }
            await _userManager.AddToRoleAsync(tutor, "Tutor");

            return Mapper.MapTutorToResponse(tutor);
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
