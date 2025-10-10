using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Repositories;
using EducationManagementSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EducationManagementSystem.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository repo)
        {
            _classRepository = repo;
        }

        public async Task<ClassResponseViewModel> AddClassAsync(ClassRequestViewModel model)
        {
            var existingClass = await _classRepository.GetAllClassesAsync();
            if (existingClass.Any(c =>
                c.ClassName.ToLower() == model.ClassName.ToLower() &&
                c.Section.ToLower() == model.Section.ToLower()))
            {
                return null;
            }

            if (existingClass.Any(c => c.InchargeId == model.InchargeId))
            {
                return null;
            }

            var newClass = Mapper.MapClassRequestToClass(model);

            await _classRepository.AddClassAsync(newClass);

            return Mapper.MapClassToClassResponse(newClass);
        }


        public async Task<IEnumerable<ClassResponseViewModel>> GetAllClassesAsync()
        {
            var classes = await _classRepository.GetAllClassesAsync();
            return 
                classes.Select(Mapper.MapClassToClassResponse);
        }

        public async Task<ClassResponseViewModel> GetClassByInchargeIdAsync(string inchargeId)
        {
            var entity = await _classRepository.GetClassByInchargeIdAsync(inchargeId);
            return 
                Mapper.MapClassToClassResponse(entity);
        }

        public async Task<ClassResponseViewModel> AddStudentToClassAsync(AddStudentToClassViewModel model)
        {
            var classEntity = await _classRepository.GetByIdAsync(model.ClassId);
            var student = await _classRepository.GetStudentByIdAsync(model.StudentId);

            if (classEntity == null|| student == null)
                return null;

            if (classEntity.Students?.Any(s => s.Id == model.StudentId) == true)
                return null;

            if (student.ClassId != null && student.ClassId != model.ClassId)
                return null;

            var updatedClass = await _classRepository.AddStudentToClassAsync(model.ClassId, model.StudentId);

            return Mapper.MapClassToClassResponse(updatedClass);
        }
    }
}
