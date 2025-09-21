namespace EducationManagementSystem.Models
{
    public class ExamBoard
    {
        public Guid ExamBoardId { get; set; }
        public string ExamBoardName { get; set; }
        public ICollection<SubjectExamMapping> StudentExam { get; set; }
    }
}
