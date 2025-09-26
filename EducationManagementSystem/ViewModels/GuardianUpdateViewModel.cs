using System.ComponentModel.DataAnnotations;

namespace EducationManagementSystem.ViewModels
{
    public class GuardianUpdateViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mobile { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public int? Building { get; set; }
        public string? Street { get; set; }
        public string? AddressLine2 { get; set; }
        public string? Town { get; set; }
        public string? County { get; set; }
        public string? PostCode { get; set; }
        public string? Country { get; set; }
        public string? Profile { get; set; }
        public string? Guardian2FirstName { get; set; }
        public string? Guardian2LastName { get; set; }
        public string? Guardian2Mobile { get; set; }
        [EmailAddress]
        public string? Guardian2Email { get; set; }
        public int? Guardian2Building { get; set; }
        public string? Guardian2Street { get; set; }
        public string? Guardian2AddressLine2 { get; set; }
        public string? Guardian2Town { get; set; }
        public string? Guardian2County { get; set; }
        public string? Guardian2PostCode { get; set; }
        public string? Guardian2Country { get; set; }
        public string? Guardian2Profile { get; set; }
        public string? SafeguardingLeadContact { get; set; }
        public bool? AppStatus { get; set; }
    }
}
