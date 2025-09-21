using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationManagementSystem.Models
{
    public class Incident
    {
        [Key]
        public int IncidentId { get; set; }
        public DateOnly Date { get; set; }
        public string IncidentTitle { get; set; }   
        public string Details { get; set; }

        // FK
        public String TutorId { get; set; }
        [ForeignKey("TutorId")]
        [InverseProperty("TutorIncidents")]
        public ApplicationUser Tutor { get; set; }
        public int LessonId { get; set; }
        [ForeignKey("LessonId")]
        public Lesson Lesson { get; set; }
        public String StudentId { get; set; }
        [ForeignKey("StudentId")]
        [InverseProperty("StudentIncidents")]
        public ApplicationUser Student { get; set; }
        public ICollection<ConfidentialNote> ConfidentialNotes { get; set; }
    }
}
