namespace EducationManagementSystem.Models
{

    public class LessonNote
    {
        public int LessonNoteId { get; set; }
        public string ContentCovered { get; set; }
        public string Highlights {  get; set; }
        public string AreasToWorkOn {get; set;}
        public string StudentProgress {get; set;}
        public string HomeWork {get; set;}

        // FK
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
