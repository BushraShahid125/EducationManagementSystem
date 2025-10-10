using System;
using System.Collections.Generic;

namespace EducationManagementSystem.ViewModels
{
    public class StudentAttendanceRequestViewModel
    {
        public Guid ClassId { get; set; }
        public List<StudentAttendanceViewModel> Students { get; set; }
    }

    public class StudentAttendanceViewModel
    {
        public string StudentId { get; set; }
        public string Status { get; set; } 
    }

    public class StudentAttendanceResponseViewModel
    {
        public Guid AttendanceId { get; set; }
        public DateTime Date { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string Status { get; set; }
    }
}