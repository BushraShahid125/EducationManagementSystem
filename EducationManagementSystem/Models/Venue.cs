using System.ComponentModel.DataAnnotations;

namespace EducationManagementSystem.Models
{
    public class Venue
    {
        [Key]
        public Guid VennueId { get; set; }
        public string VennueName { get; set; }
        public string PostCode { get; set; }
        public int Building {  get; set; }
        public string Street { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string LongandLat { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
        public ICollection <ApplicationUser> Students { get; set; }

        public string Location => $"{Building} {Street}, {Town}, {County}, {PostCode}, {Country}";
    }
}
