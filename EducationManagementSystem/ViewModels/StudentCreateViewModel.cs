namespace EducationManagementSystem.ViewModels
{
    public class StudentCreateViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string? PreferredName { get; set; }
        public bool IsMale { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Address
        public int? Building { get; set; }
        public string? Street { get; set; }
        public string? AddressLine2 { get; set; }
        public string? Town { get; set; }
        public string? County { get; set; }
        public string? PostCode { get; set; }
        public string? Country { get; set; }

        // Links
        public string? ClientId { get; set; }

        // Multiple Contacts (Guardian/Relatives)
        //public List<int>? ContactIds { get; set; }
    }
}
