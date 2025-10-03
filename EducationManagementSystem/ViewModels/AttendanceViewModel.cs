using System.ComponentModel.DataAnnotations;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.ViewModels
{
    public class AttendanceRequestViewModel
    {
        [Required]
        public int LessonId { get; set; }
        public DateTime? StudentArrivedTime { get; set; }
        public DateTime? TutorArrivedTime { get; set; }
        public AttendanceStatus? Attendance { get; set; }
        public string? AttendanceDetails { get; set; }
        public string? Objective { get; set; }
    }
    public class AttendanceResponseViewModel
    {
        public int LessonId { get; set; }
        public string? StudentArrivedTime { get; set; }
        public string? TutorArrivedTime { get; set; }
        public string? Attendance { get; set; }
        public string? AttendanceDetails { get; set; }
        public string? Objective { get; set; }
    }
    public class AttendanceUpdateViewModel
    {
        public DateTime? StudentArrivedTime { get; set; }
        public DateTime? TutorArrivedTime { get; set; }
        public AttendanceStatus? Attendance { get; set; }
        public string? AttendanceDetails { get; set; }
        public string? Objective { get; set; }
    }
}
