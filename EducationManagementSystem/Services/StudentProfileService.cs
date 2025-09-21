using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IService;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using EmployeeManagementSystem.Data;

namespace EducationManagementSystem.Services
{
    public class StudentProfileService : IStudentProfileService
    {
        private readonly IStudentProfileRepository _repository;

        public StudentProfileService(IStudentProfileRepository repository)
        {
            _repository = repository;
        }

        //  Get/profile
        public async Task<StudentProfileViewModel?> GetProfileAsync(string studentId)
        {
            var student = await _repository.GetStudentByIdAsync(studentId);
            return Mapper.MapStudentToStudentProfileViewModel(student);
        }


        //Add/Update/Profile
        public async Task<StudentProfileViewModel> AddUpdateProfileAsync(StudentProfileViewModel model)
        {
            var student = await _repository.GetStudentByIdAsync(model.StudentId);
            if (student == null)
                return null;

            Mapper.MapStudentProfileViewModelToStudent(model, student);

            await _repository.AddUpdateProfileAsync(student);

            return model;
        }


    }
}
