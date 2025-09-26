using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Interfaces.IServices
{
    public interface IStudentGroupService
    {
        Task<StudentGroupResponseViewModel> AddStudentGroupAsync (StudentGroupRequestViewModel model);
        Task<ICollection<StudentGroupListViewModel>> GetAllStudentGroupsAsync(StudentGroupSearchViewModel filter);
    }
}