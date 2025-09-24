namespace EducationManagementSystem.ViewModels
{
    public class HomeWorkRequestViewModel
    {
        public DateTime Date { get; set; }
        public Guid SubjectId { get; set; }
        public string TutorId { get; set; }
        public string Description { get; set; }
    }
}
