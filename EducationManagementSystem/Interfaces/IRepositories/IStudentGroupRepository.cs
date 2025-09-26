using EducationManagementSystem.Models;

namespace EducationManagementSystem.Interfaces.IRepositories
{
    public interface IStudentGroupRepository
    {
        Task<StudentGroup> AddStudentGroupAsync(StudentGroup studentGroup);
        Task<IEnumerable<StudentGroup>> GetAllStudentGroupAsync();
        Task<ICollection<StudentGroup>> GetStudentGroupsWithFilterAsync();
    }
}
