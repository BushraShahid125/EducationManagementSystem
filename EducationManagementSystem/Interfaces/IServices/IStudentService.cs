using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace EducationManagementSystem.Interfaces.IService
{
    public interface IStudentService
    {
        Task<ApplicationUser> AddStudentDetailsAsync(StudentCreateViewModel model);
    }
}