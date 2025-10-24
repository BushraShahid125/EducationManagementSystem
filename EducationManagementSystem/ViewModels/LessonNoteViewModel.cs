namespace EducationManagementSystem.ViewModels
{
    public class LessonNoteRequestViewModel
    {
        public int LessonId { get; set; }
        public string ContentCovered { get; set; }
        public string Highlights { get; set; }
        public string AreasToWorkOn { get; set; }
        public string StudentProgress { get; set; }
        public string HomeWork { get; set; }
    }

    public class LessonNoteResponseViewModel
    {
        public string ContentCovered { get; set; }
        public string Highlights { get; set; }
        public string AreasToWorkOn { get; set; }
        public string StudentProgress { get; set; }
        public string HomeWork { get; set; }
    }

    public class LessonNoteUpdateViewModel
    {
        public string ContentCovered { get; set; }
        public string Highlights { get; set; }
        public string AreasToWorkOn { get; set; }
        public string StudentProgress { get; set; }
        public string HomeWork { get; set; }
    }
}