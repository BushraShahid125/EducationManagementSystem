using Azure.Core;
using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;

        public SubjectService(ISubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<SubjectResponseViewModel> CreateSubjectAsync(SubjectRequestViewModel model)
        {
            var existing = (await _repository.GetAllAsync())
                .FirstOrDefault(x => x.SubjectName.ToLower() == model.SubjectName.ToLower());

            if (existing != null)
            {
                return null;
            }
            var subject = Mapper.MapSubjectRequestToSubject(model);
            var created = await _repository.CreateAsync(subject);
            return Mapper.MapSubjectToSubjectResponse(created);
        }

        public async Task<SubjectResponseViewModel> UpdateSubjectAsync(SubjectUpdateViewModel model)
        {
            var subject = await _repository.GetByIdAsync(model.SubjectId);
            if (subject == null) return null;

            Mapper.MapSubjectUpdateToSubject(model, subject);
            var updated = await _repository.UpdateAsync(subject);
            return Mapper.MapSubjectToSubjectResponse(updated);
        }

        public async Task<SubjectResponseViewModel> GetSubjectByIdAsync(Guid subjectId)
        {
            var subject = await _repository.GetByIdAsync(subjectId);
            return Mapper.MapSubjectToSubjectResponse(subject);
        }

        public async Task<IEnumerable<SubjectResponseViewModel>> GetAllSubjectsAsync()
        {
            var subjects = await _repository.GetAllAsync();
            return subjects.Select(Mapper.MapSubjectToSubjectResponse);
        }
    }
}
