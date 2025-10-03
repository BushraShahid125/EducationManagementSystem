using System.ComponentModel.DataAnnotations;

namespace EducationManagementSystem.ViewModels
{
    public class TutorRequestViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }
        public int Building { get; set; }
        public string Street { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public bool AppStatus { get; set; } = true;
    }

    public class TutorUpdateViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mobile { get; set; }
        public int? Building { get; set; }
        public string? Street { get; set; }
        public string? AddressLine2 { get; set; }
        public string? Town { get; set; }
        public string? County { get; set; }
        public string? PostCode { get; set; }
        public string? Country { get; set; }
        public bool AppStatus { get; set; } = true;
    }


    public class TutorResponseViewModel
    {
        public string TutorId { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }
        public int? Building { get; set; }
        public string Street { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public bool AppStatus { get; set; }
        public bool IsArchived { get; set; }
    }
    public class TutorSearchRequestViewModel
    {
        public string? Name { get; set; }
        public string? County { get; set; }
        public string? PostCode { get; set; }

        public int PageNumber { get; set; } = 1; 
        public int PageSize { get; set; } = 10; 
    }

}
