namespace EducationManagementSystem.Models
{

    public class LessonNote
    {
        public int LessonNoteId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        // FK
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
