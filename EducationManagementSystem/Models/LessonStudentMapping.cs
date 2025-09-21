using System.ComponentModel.DataAnnotations;

namespace EducationManagementSystem.Models
{
    public class LessonStudentMapping
    {
        [Key]
        public Guid LessonStudentId { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
    }
}
