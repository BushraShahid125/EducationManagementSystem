namespace EducationManagementSystem.ViewModels
{
    public class HomeWorkResponseViewModel
    {
        public int HomeWorkId { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }   
        public string Tutor { get; set; }   
        public string Description { get; set; }
    }
}