using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.Models
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        public TimeOnly StartTime { get; set; }
        public DateOnly DateofLesson { get; set; }
        public TimeSpan Duration { get; set; }
        public ClassFormat Format {  get; set; }
        public int TeachingYear { get; set; }
        public DateTime? StudentArrivedTime { get; set; }
        public DateTime? TutorArrivedTime { get; set; }
        public AttendanceStatus? Attendance { get; set; }     
        public string? AttendanceDetails { get; set; }
        public LessonStatus? Status { get; set; }
        public bool? IsApproved { get; set; }
        public string? Objective { get; set; }
        public string? SafeguardingNotes { get; set; }


        public ICollection<Incident> Incidents { get; set; }
        public ICollection<LessonNote> LessonNotes { get; set; }
        public ICollection<LessonStudentMapping> LessonStudents { get; set; }
        public ICollection<ConfidentialNote> ConfidentialNotes { get; set; }

        //FK
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public String TutorId { get; set; }
        [ForeignKey("TutorId")]
        [InverseProperty("TutorLessons")]
        public ApplicationUser Tutor { get; set; }

        public String ClientId {  get; set; }
        [ForeignKey("ClientId")]
        [InverseProperty("ClientLessons")]
        public ApplicationUser Client { get; set; }

        public Guid VenueId { get; set; }
        public Venue Venue { get; set; }

        public Guid StudentGroupId { get; set; }
        public StudentGroup StudentGroup { get; set; }
    }
}
