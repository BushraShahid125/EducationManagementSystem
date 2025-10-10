using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationManagementSystem.Models
{
    public class Attendance
    {
        [Key]
        public Guid AttendanceId { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        [Required]
        [ForeignKey("Student")]
        public string StudentId { get; set; } 
        public virtual ApplicationUser Student { get; set; }

        [ForeignKey("Class")]
        public Guid? ClassId { get; set; }
        public virtual Class? Class { get; set; }
        public string Status { get; set; }
    }
}