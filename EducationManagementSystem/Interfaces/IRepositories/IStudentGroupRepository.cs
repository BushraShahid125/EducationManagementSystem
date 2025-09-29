using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Interfaces.IRepositories
{
    public interface IStudentGroupRepository
    {
        Task<StudentGroup> AddStudentGroupAsync(StudentGroup studentGroup);
        IQueryable<StudentGroup> GetAllStudentGroups();
    }
}