namespace EducationManagementSystem.ViewModels
{
    public class ClientResponseViewModel
    {
        public string ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int? Building { get; set; }
        public string Street { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string ContactTelephone { get; set; }
        public string ContactEmail { get; set; }
        public bool AppStatus { get; set; }
    }
}
