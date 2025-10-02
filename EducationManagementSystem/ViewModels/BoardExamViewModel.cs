namespace EducationManagementSystem.ViewModels
{
    public class ExamBoardRequestViewModel
    {
        public string ExamBoardName { get; set; }
    }

    public class ExamBoardUpdateViewModel
    {
        public Guid ExamBoardId { get; set; }
        public string ExamBoardName { get; set; }
    }

    public class ExamBoardResponseViewModel
    {
        public Guid ExamBoardId { get; set; }
        public string ExamBoardName { get; set; }
    }
}
