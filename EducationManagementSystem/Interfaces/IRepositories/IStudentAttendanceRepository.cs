using EducationManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationManagementSystem.Interfaces.IRepositories
{
    public interface IStudentAttendanceRepository
    {
        Task<List<Attendance>> GetAttendanceByClassAsync(Guid classId);
        Task AddAttendanceAsync(List<Attendance> attendances);
        Task<bool> IsAttendanceAlreadyMarkedAsync(Guid classId, DateTime date);
        Task<bool> IsClassOwnedByInchargeAsync(Guid classId, string tutorId);
    }
}
