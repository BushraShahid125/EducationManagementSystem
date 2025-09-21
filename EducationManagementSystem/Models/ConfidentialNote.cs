using System.ComponentModel.DataAnnotations.Schema;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.Models
{
    public class ConfidentialNote
    {
        public int ConfidentialNoteId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public NoteType Type { get; set; }
        public string Content { get; set; }

        //  FK
        public int LessonId { get; set; }   
        public Lesson Lesson { get; set; }
        public String TutorId { get; set; }
        [ForeignKey("TutorId")]
        [InverseProperty("TutorConfidentialNotes")]
        public ApplicationUser Tutor { get; set; }
        public int? IncidentId { get; set; }
        public Incident Incident { get; set; }
        public String StudentId { get; set;}
        [ForeignKey("StudentId")]
        [InverseProperty("StudentConfidentialNotes")]
        public ApplicationUser Student { get; set; }
    }
}
