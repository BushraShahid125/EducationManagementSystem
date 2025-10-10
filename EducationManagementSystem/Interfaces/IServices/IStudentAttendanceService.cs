using EducationManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationManagementSystem.Interfaces.IServices
{
    public interface IStudentAttendanceService
    {
        Task<IEnumerable<StudentAttendanceResponseViewModel>> MarkAttendanceAsync(StudentAttendanceRequestViewModel model, string tutorId);
        Task<IEnumerable<StudentAttendanceResponseViewModel>> GetAttendanceByClassAsync(Guid classId);
    }
}
