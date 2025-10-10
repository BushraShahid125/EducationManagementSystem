using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Services
{
    public class StudentAttendanceService : IStudentAttendanceService
    {
        private readonly IStudentAttendanceRepository _repository;

        public StudentAttendanceService(IStudentAttendanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StudentAttendanceResponseViewModel>> MarkAttendanceAsync(StudentAttendanceRequestViewModel model, string inchargeId)
        {
            var isOwner = await _repository.IsClassOwnedByInchargeAsync(model.ClassId, inchargeId);
            if (!isOwner)
                return null;

            var alreadyMarked = await _repository.IsAttendanceAlreadyMarkedAsync(model.ClassId, DateTime.Now.Date);
            if (alreadyMarked)
                return null;

            var attendanceList = Mapper.MapAttendanceRequestToAttendance(model);
            await _repository.AddAttendanceAsync(attendanceList);

            return attendanceList.Select(Mapper.MapAttendanceToResponse).ToList();
        }

        public async Task<IEnumerable<StudentAttendanceResponseViewModel>> GetAttendanceByClassAsync(Guid classId)
        {
            var attendances = await _repository.GetAttendanceByClassAsync(classId);
            return attendances.Select(Mapper.MapAttendanceToResponse);
        }
    }
}
