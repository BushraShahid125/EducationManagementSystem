namespace EducationManagementSystem.ViewModels
{
    public class StudentGroupRequestViewModel
    {
        public string GroupName { get; set; }
        public string PostCode { get; set; }
    }

    public class StudentGroupResponseViewModel
    {
        public Guid StudentGroupId { get; set; }
        public string GroupName { get; set; }
        public string PostCode { get; set; }
    }
    
    public class StudentGroupListViewModel
    {
        public string GroupName { get; set; }
    }
    public class StudentGroupSearchViewModel
    {
        public string? SearchKey { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
