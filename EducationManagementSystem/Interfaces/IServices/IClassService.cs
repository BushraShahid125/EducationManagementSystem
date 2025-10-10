using EducationManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationManagementSystem.Interfaces.IServices
{
    public interface IClassService
    {
        Task<ClassResponseViewModel> AddClassAsync(ClassRequestViewModel model);
        Task<IEnumerable<ClassResponseViewModel>> GetAllClassesAsync();
        Task<ClassResponseViewModel> GetClassByInchargeIdAsync(string inchargeId);
        Task<ClassResponseViewModel> AddStudentToClassAsync(AddStudentToClassViewModel model);
    }
}
