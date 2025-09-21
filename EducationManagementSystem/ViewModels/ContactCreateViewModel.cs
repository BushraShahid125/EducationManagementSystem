using System.ComponentModel.DataAnnotations;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.ViewModels
{
    public class ContactCreateViewModel
    {
        [Required]
        public string ContactName { get; set; }

        [Required]
        public string Mobile { get; set; }  

        [EmailAddress]
        public string Email { get; set; }

        public  string JobTitle { get; set; }

        public string Report { get; set; }

        public ReportTrigger Trigger { get; set; }
        public string ClientId { get; set; }
    }
}
