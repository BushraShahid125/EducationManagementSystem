using EducationManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationManagementSystem.Interfaces.IRepositories
{
    public interface IClassRepository
    {
        Task<Class> AddClassAsync(Class entity);
        Task<IEnumerable<Class>> GetAllClassesAsync();
        Task<Class> GetClassByInchargeIdAsync(string inchargeId);
        Task<Class> GetByIdAsync(Guid classId);
        Task<Class> AddStudentToClassAsync(Guid classId, string studentId);
        Task<ApplicationUser?> GetStudentByIdAsync(string studentId);
    }
}