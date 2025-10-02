namespace EducationManagementSystem.ViewModels
{
    public class SubjectRequestViewModel
    {
        public string SubjectName { get; set; }
    }

    public class SubjectUpdateViewModel
    {
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
    }

    public class SubjectResponseViewModel
    {
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}
