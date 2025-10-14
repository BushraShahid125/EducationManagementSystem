namespace EducationManagementSystem.ViewModels
{
    public class IncidentRequestViewModel
    {
        public DateOnly Date {  get; set; }
        public String TutorId { get; set; }
        public String StudentId { get; set; }
        public string IncidentTitle { get; set; }
        public string Details { get; set; }
        public int LessonId { get; set; }
    }

    public class IncidentResponseViewModel
    {
        public DateOnly Date { get; set; }
        public String TutorId { get; set; }
        public String StudentId { get; set; }
        public string IncidentTitle { get; set; }
        public string Details { get; set; }
        public int LessonId { get; set; }
    }
    public class IncidentSearchRequestViewModel
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class IncidentListViewModel
    {
        public DateOnly Date { get; set; }
        public string Tutor { get; set; }
        public string Student { get; set; }
        public string Incident { get; set; }
        public string Details { get; set; }
    }
    public class PagedIncidentListResponse
    {
        public List<IncidentListViewModel> Items { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

}
