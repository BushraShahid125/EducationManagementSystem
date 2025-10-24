using System.ComponentModel.DataAnnotations;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.ViewModels
{
    public class ConfidentialNoteRequestViewModel
    {
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public TimeOnly Time { get; set; }
        [Required]
        public NoteType Type { get; set; }
        public int LessonId { get; set; }
        public String TutorId { get; set; }
        public int? IncidentId { get; set; }
        public String StudentId { get; set; }
        [Required]
        public string Content { get; set; }
    }
    public class ConfidentialNoteResponseViewModel
    {
        public int ConfidentialNoteId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public string Lesson {  get; set; }
        public string Tutor { get; set; }
        public int? Incident { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }

    public class ConfidentialNoteUpdateViewModel
    {
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public TimeOnly Time { get; set; }
        [Required]
        public NoteType Type { get; set; }
        [Required]
        public int LessonId { get; set; }
        [Required]
        public String TutorId { get; set; }
        [Required]
        public int? Incident { get; set; }
        [Required]
        public string Content { get; set; }
    }
}