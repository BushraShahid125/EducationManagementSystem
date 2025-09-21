using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.ViewModels
{
    public class ContactResponseViewModel
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Report { get; set; }
        public ReportTrigger Trigger { get; set; }
        public string ClientId { get; set; }
    }
}
