namespace EducationManagementSystem.ViewModels
{
    public class VenueResponseViewModel
    {
        public Guid VenueId { get; set; }
        public string VenueName { get; set; }
        public string PostCode { get; set; }
        public int Building { get; set; }
        public string Street { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string LongandLat { get; set; }
    }
}