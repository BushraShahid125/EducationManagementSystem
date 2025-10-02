namespace EducationManagementSystem.ViewModels
{
    public class StudentSubjectRequestViewModel
    {
        public string StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid ExamBoardId { get; set; }
    }

    public class StudentSubjectResponseViewModel
    {
        public Guid StudentSubjectId { get; set; }
        public string StudentId { get; set; }
        public string SubjectName { get; set; }
        public string ExamBoardName { get; set; }
    }
}
