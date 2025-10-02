namespace EducationManagementSystem.ViewModels
{
    public class SubjectExamMappingRequestViewModel
    {
        public Guid SubjectId { get; set; }
        public Guid ExamBoardId { get; set; }
    }

    public class SubjectExamMappingResponseViewModel
    {
        public int SubjectExamMappingId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid ExamBoardId { get; set; }
    }
}
